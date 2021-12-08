using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Entities;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var users = await Request<List<ApplicationUser>>.GetAsync(APILinks.USERS_URL + "/GetAllUsers", token);
            var publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            var developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            List<Entities.UserViewModel> usr = new();
            users.ForEach(u => usr.Add(new()
            {
                UserProperties = u,
                Developer = developers != null ? developers.FirstOrDefault(d => d.User.Id == u.Id) : null,
                Publisher = publishers != null ? publishers.FirstOrDefault(p => p.User.Id == u.Id) : null,
                //Roles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetUserRoles/" + u.Email, token)
            }));
            return View(usr);
        }
        public async Task<ActionResult> Edit(string id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var user = await Request<Entities.UserViewModel>.GetAsync(APILinks.USERS_URL + "/GetUser/" + id, token);
            if (user != null)
            {
                var userRoles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetUserRoles/" + user.UserProperties.Email, token);
                Entities.UserViewModel usr = new()
                {
                    UserProperties = user.UserProperties,
                    Roles = userRoles.Select(usrRole => usrRole).ToList(),
                };
                var allRoles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetAllRoles", token);
                ViewModels.AdminUserViewModel userViewModel = new ViewModels.AdminUserViewModel()
                {
                    User = usr,
                    Roles = allRoles.Select(role => new SelectListItem
                    {
                        Text = role,
                        Value = role,
                        Selected = usr.Roles.Contains(role)
                    })
                };

                return View(userViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewModels.AdminUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(new {Roles = userViewModel.User.Roles });
                await Request<ViewModelBase>.PostAsync(APILinks.USERS_URL + "/UpdateUserRoles/" + userViewModel.User.UserProperties.Email, jsonObject, token: token);
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var user = await Request<ApplicationUser>.GetAsync(APILinks.USERS_URL + "/GetUser/" + id, token);
            if (user != null)
            {

                var publisher = await Request<PublisherDto>.GetAsync(APILinks.PUBLISHER_URL + "/GetPublisherByUserId/" + id, token);
                var developer = await Request<DeveloperDto>.GetAsync(APILinks.DEVELOPER_URL + "/GetDeveloperByUserId/" + id, token);
                Entities.UserViewModel usr = new()
                {
                    UserProperties = user,
                    Developer = developer,
                    Publisher = publisher,
                    Roles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetUserRoles/" + user.Email, token)
                };
                return View(usr);
            }
            return NotFound();
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var user = await Request<ApplicationUser>.GetAsync(APILinks.USERS_URL + "/GetUser/" + id, token);
            if (user != null)
            {

                var publisher = await Request<PublisherDto>.GetAsync(APILinks.PUBLISHER_URL + "/GetPublisherByUserId/" + id, token);
                var developer = await Request<DeveloperDto>.GetAsync(APILinks.DEVELOPER_URL + "/GetDeveloperByUserId/" + id, token);
                Entities.UserViewModel usr = new()
                {
                    UserProperties = user,
                    Developer = developer,
                    Publisher = publisher,
                    Roles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetUserRoles/" + user.Email, token)
                };
                return View(usr);
            }
            return NotFound();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            await Request<string>.DeleteAsync(APILinks.USERS_URL + "/DeleteUser/" + id, token);
            return RedirectToAction("Index");
        }
    }
}
