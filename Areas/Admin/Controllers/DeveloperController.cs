using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeveloperController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            return View(Developers);
        }

        // GET: DeveloperController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.DEVELOPER_URL + "/" + id;
            return View(await Request<DeveloperDto>.GetAsync(link, token));
        }

        // GET: DeveloperController/Create
        public async Task<ActionResult> Create()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var users = await Request<List<IdentityUser>>.GetAsync(APILinks.USERS_URL + "/GetAllUsers", token);
            DeveloperViewModel publisherViewModel = new()
            {
                Users = users.Select(user => new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id,
                }),
            };
            return View(publisherViewModel);
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeveloperViewModel developerViewModel)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempPath();
                var p = Path.Combine(filePath, developerViewModel.CreateDeveloper.Cover.FileName);
                using var stream = new FileStream(p, FileMode.Create);
                developerViewModel.CreateDeveloper.Cover.CopyTo(stream);
                stream.Close();
                List<(string, string)> filePaths = new()
                {
                    (p, "Cover"),
                };
                List<(string, string)> variables = new();
                variables.Add(("Name", developerViewModel.CreateDeveloper.Name));
                variables.Add(("Description", developerViewModel.CreateDeveloper.Description));
                variables.Add(("WebsiteLink", developerViewModel.CreateDeveloper.WebsiteLink));
                variables.Add(("FacebookLink", developerViewModel.CreateDeveloper.FacebookLink));
                variables.Add(("TwitterLink", developerViewModel.CreateDeveloper.TwitterLink));
                variables.Add(("UserId", developerViewModel.CreateDeveloper.UserId));
                var token = Request.Cookies[Constants.JWT.ToString()];
                var rep = await Request<DeveloperDto>.PostAsync(APILinks.DEVELOPER_URL, null, "multipart/form-data", token: token, filePaths, variables);
                if (rep.Success)
                {
                    return RedirectToAction("Index");
                }
                var test = rep.Errors[0];
                return View(developerViewModel);
            }
            return View(developerViewModel);
        }

        // GET: DeveloperController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var users = await Request<List<IdentityUser>>.GetAsync(APILinks.USERS_URL + "/GetAllUsers", token);
            string link = APILinks.DEVELOPER_URL + "/" + id;
            var UpdateDeveloperDto = await Request<UpdateDeveloperDto>.GetAsync(link, token);
            DeveloperViewModel publisherViewModel = new()
            {
                Users = users.Select(user => new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id,
                    Selected = UpdateDeveloperDto.User.Id == user.Id ? true : false
                }),
                UpdateDeveloper = UpdateDeveloperDto,
            };
            return View(publisherViewModel);

        }

        // POST: DeveloperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeveloperViewModel developerViewModel)
        {

            if (ModelState.IsValid)
            {
                List<(string, string)> filePaths = new();
                if (developerViewModel.UpdateDeveloper.Cover != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, developerViewModel.UpdateDeveloper.Cover.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, developerViewModel.UpdateDeveloper.Cover.FileName), FileMode.Create);
                    developerViewModel.UpdateDeveloper.Cover.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "Cover"));
                }
                List<(string, string)> variables = new();
                variables.Add(("Name", developerViewModel.UpdateDeveloper.Name));
                variables.Add(("Description", developerViewModel.UpdateDeveloper.Description));
                variables.Add(("WebsiteLink", developerViewModel.UpdateDeveloper.WebsiteLink));
                variables.Add(("FacebookLink", developerViewModel.UpdateDeveloper.FacebookLink));
                variables.Add(("TwitterLink", developerViewModel.UpdateDeveloper.TwitterLink));
                variables.Add(("UserId", developerViewModel.UpdateDeveloper.UserId));
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<UpdateDeveloperDto>.PutAsync(APILinks.DEVELOPER_URL + "/" + id, null, "multipart/form-data", token: token, filePaths, variables: variables);
                return RedirectToAction("Index");
            }
            return View(developerViewModel);
        }

        // GET: DeveloperController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.DEVELOPER_URL + "/" + id;
            return View(await Request<DeveloperDto>.GetAsync(link, token));
        }

        // POST: DeveloperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DeveloperDto DevelopertDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<DeveloperDto>.DeleteAsync(APILinks.DEVELOPER_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(DevelopertDto);
        }
    }
}
