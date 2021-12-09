using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublisherController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            return View(Publishers);
        }

        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.PUBLISHER_URL + "/" + id;
            return View(await Request<PublisherDto>.GetAsync(link, token));
        }

        // GET: PublisherController/Create
        public async Task<ActionResult> Create()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var users = await Request<List<ApplicationUser>>.GetAsync(APILinks.USERS_URL + "/GetAllUsers", token);
            PublisherViewModel publisherViewModel = new()
            {
                Users = users.Select(user => new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id,
                }),
            };
            return View(publisherViewModel);
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PublisherViewModel PublisherViewModel)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempPath();
                var p = Path.Combine(filePath, PublisherViewModel.CreatePublisher.Cover.FileName);
                using var stream = new FileStream(Path.Combine(filePath, PublisherViewModel.CreatePublisher.Cover.FileName), FileMode.Create);
                PublisherViewModel.CreatePublisher.Cover.CopyTo(stream);
                stream.Close();
                List<(string, string)> filePaths = new()
                {
                    (p, "Cover"),
                };
                List<(string, string)> variables = new();
                variables.Add(("Name", PublisherViewModel.CreatePublisher.Name));
                variables.Add(("Description", PublisherViewModel.CreatePublisher.Description));
                variables.Add(("WebsiteLink", PublisherViewModel.CreatePublisher.WebsiteLink));
                variables.Add(("FacebookLink", PublisherViewModel.CreatePublisher.FacebookLink));
                variables.Add(("TwitterLink", PublisherViewModel.CreatePublisher.TwitterLink));
                variables.Add(("UserId", PublisherViewModel.CreatePublisher.UserId));
                var token = Request.Cookies[Constants.JWT.ToString()];
                var rep = await Request<PublisherDto>.PostAsync(APILinks.PUBLISHER_URL, null, "multipart/form-data", token: token, filePaths, variables);
                if (rep.Success)
                {
                    return RedirectToAction("Index");
                }
                var test = rep.Errors[0];
                return View(PublisherViewModel);
            }
            return View(PublisherViewModel);
        }

        // GET: PublisherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var users = await Request<List<ApplicationUser>>.GetAsync(APILinks.USERS_URL + "/GetAllUsers", token);
            string link = APILinks.PUBLISHER_URL + "/" + id;
            var UpdatePublisherDto = await Request<UpdatePublisherDto>.GetAsync(link, token);
            PublisherViewModel publisherViewModel = new()
            {
                Users = users.Select(user => new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id,
                    Selected = UpdatePublisherDto.User?.Id == user.Id ? true : false
                }),
                UpdatePublisher = UpdatePublisherDto,
            };
            return View(publisherViewModel);

        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PublisherViewModel PublisherViewModel)
        {

            if (ModelState.IsValid)
            {
                List<(string, string)> filePaths = new();
                if (PublisherViewModel.UpdatePublisher.Cover != null)
                {
                    var filePath = Path.GetTempPath();
                    var p = Path.Combine(filePath, PublisherViewModel.UpdatePublisher.Cover.FileName);
                    using var stream = new FileStream(Path.Combine(filePath, PublisherViewModel.UpdatePublisher.Cover.FileName), FileMode.Create);
                    PublisherViewModel.UpdatePublisher.Cover.CopyTo(stream);
                    stream.Close();
                    filePaths.Add((p, "Cover"));
                }
                List<(string, string)> variables = new();
                variables.Add(("Name", PublisherViewModel.UpdatePublisher.Name));
                variables.Add(("Description", PublisherViewModel.UpdatePublisher.Description));
                variables.Add(("WebsiteLink", PublisherViewModel.UpdatePublisher.WebsiteLink));
                variables.Add(("FacebookLink", PublisherViewModel.UpdatePublisher.FacebookLink));
                variables.Add(("TwitterLink", PublisherViewModel.UpdatePublisher.TwitterLink));
                variables.Add(("UserId", PublisherViewModel.UpdatePublisher.UserId));
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<UpdatePublisherDto>.PutAsync(APILinks.PUBLISHER_URL + "/" + id, null, "multipart/form-data", token: token, filePaths, variables: variables);
                return RedirectToAction("Index");
            }
            return View(PublisherViewModel);
        }

        // GET: PublisherController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.PUBLISHER_URL + "/" + id;
            return View(await Request<PublisherDto>.GetAsync(link, token));
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PublisherDto PublishertDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<string>.DeleteAsync(APILinks.PUBLISHER_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(PublishertDto);
        }
    }
}
