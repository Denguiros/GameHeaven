using GameHeaven.Configuration;
using GameHeaven.Dtos;
using GameHeaven.Dtos.UserDtos;
using GameHeaven.Entities;
using GameHeaven.ViewModels;
using GameHeavenAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(Roles.User))]
    public class UserController : Controller
    {
        // GET: UserProfileController
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            if (TempData["ViewModelBase"] is not null)
            {
                var viewModelBase = JsonConvert.DeserializeObject<ViewModelBase>(TempData["ViewModelBase"].ToString());
                var user = HttpContext.Session.GetObject<ApplicationUser>("User");
                user.Messages = viewModelBase.Messages;
                return View(user);
            }
            return View(HttpContext.Session.GetObject<ApplicationUser>("User"));
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var currentUser = HttpContext.Session.GetObject<ApplicationUser>("User");
            UpdateUserDto updateUserDto = new()
            {
                Email = currentUser.UserProperties.Email,
                UserName = currentUser.UserProperties.UserName,
                FacebookLink = currentUser.FacebookLink,
                InstagramLink = currentUser.InstagramLink,
                TwitterLink = currentUser.TwitterLink,
            };
            return View(updateUserDto);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UpdateUserDto updateUserDto)
        {
            if (ModelState.IsValid)
            {
                List<(string, string)> filePaths = new();
                if (updateUserDto.Cover != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, updateUserDto.Cover.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, updateUserDto.Cover.FileName), FileMode.Create);
                    updateUserDto.Cover.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "Cover"));
                }
                if (updateUserDto.ProfilePicture != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, updateUserDto.ProfilePicture.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, updateUserDto.ProfilePicture.FileName), FileMode.Create);
                    updateUserDto.ProfilePicture.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "ProfilePicture"));
                }
                List<(string, string)> variables = new();
                variables.Add(("UserName", updateUserDto.UserName));
                variables.Add(("Email", updateUserDto.Email));
                variables.Add(("InstagramLink", updateUserDto.InstagramLink));
                variables.Add(("FacebookLink", updateUserDto.FacebookLink));
                variables.Add(("TwitterLink", updateUserDto.TwitterLink));
                variables.Add(("Password", updateUserDto.Password));
                var token = Request.Cookies[Constants.JWT.ToString()];
                var userId = HttpContext.Session.GetObject<ApplicationUser>("User").UserProperties.Id;
                var userResult = await Request<AuthResult>.PutAsync(APILinks.USERS_URL + "/UpdateUser/" + userId, null, "multipart/form-data", token: token, filePaths, variables: variables);

                if (userResult.Success)
                {
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(userResult);
                    HttpContext.Session.SetObject("User", userResult.User);
                    return RedirectToAction("Index");
                }
                updateUserDto.Errors = userResult.Errors;
                return View(updateUserDto);
            }
            return View(updateUserDto);
        }
    }

}
