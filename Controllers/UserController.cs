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
            if (TempData["ViewModelBase"] is not null)
            {
                var viewModelBase = JsonConvert.DeserializeObject<ViewModelBase>(TempData["ViewModelBase"].ToString());
                var user = HttpContext.Session.GetObject<Entities.UserViewModel>("User");
                user.Messages = viewModelBase.Messages;
                return View(user);
            }
            var userInSession = HttpContext.Session.GetObject<Entities.UserViewModel>("User");
            return View(userInSession);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var currentUser = HttpContext.Session.GetObject<Entities.UserViewModel>("User");
            UpdateUserDto updateUserDto = new()
            {
                Email = currentUser.UserProperties.Email,
                UserName = currentUser.UserProperties.UserName,
                FacebookLink = currentUser.UserProperties.FacebookLink,
                InstagramLink = currentUser.UserProperties.InstagramLink,
                TwitterLink = currentUser.UserProperties.TwitterLink,
            };
            return View(updateUserDto);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UpdateUserDto updateUser)
        {
            if (ModelState.IsValid)
            {
                List<(string, string)> filePaths = new();
                if (updateUser.Cover != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, updateUser.Cover.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, updateUser.Cover.FileName), FileMode.Create);
                    updateUser.Cover.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "Cover"));
                }
                if (updateUser.ProfilePicture != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, updateUser.ProfilePicture.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, updateUser.ProfilePicture.FileName), FileMode.Create);
                    updateUser.ProfilePicture.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "ProfilePicture"));
                }
                List<(string, string)> variables = new();
                variables.Add(("UserName", updateUser.UserName));
                variables.Add(("Email", updateUser.Email));
                variables.Add(("InstagramLink", updateUser.InstagramLink));
                variables.Add(("FacebookLink", updateUser.FacebookLink));
                variables.Add(("TwitterLink", updateUser.TwitterLink));
                variables.Add(("Password", updateUser.Password));
                var token = Request.Cookies[Constants.JWT.ToString()];
                var userId = HttpContext.Session.GetObject<Entities.UserViewModel>("User").UserProperties.Id;
                var userResult = await Request<AuthResult>.PutAsync(APILinks.USERS_URL + "/UpdateUser/" + userId, null, "multipart/form-data", token: token, filePaths, variables: variables);

                if (userResult.Success)
                {
                    TempData["ViewModelBase"] = JsonConvert.SerializeObject(userResult);
                    HttpContext.Session.SetObject("User", userResult.User);
                    return RedirectToAction("Index");
                }
                updateUser.Errors = userResult.Errors;
                return View(updateUser);
            }
            return View(updateUser);
        }
    }

}
