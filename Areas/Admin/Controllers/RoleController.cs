using GameHeaven.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var roles = await Request<List<string>>.GetAsync(APILinks.USERS_URL + "/GetAllRoles", token);
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Role createRole)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createRole);
                await Request<Role>.PostAsync(APILinks.USERS_URL+ "/CreateRole/"+createRole.Name, jsonObject, token: token);
                return RedirectToAction("Index");
            }
            return View(createRole);
        }



        // POST: OsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string role)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            await Request<Role>.DeleteAsync(APILinks.USERS_URL + "/RemoveRole/" + role, token);
            return RedirectToAction("Index");
        }
    }
}
