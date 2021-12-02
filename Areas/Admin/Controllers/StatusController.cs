using GameHeaven.Dtos.StatusDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class StatusController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Statuss = await Request<List<StatusDto>>.GetAsync(APILinks.STATUS_URL, token);
            return View(Statuss);
        }

        // GET: StatusController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.STATUS_URL + "/" + id;
            return View(await Request<StatusDto>.GetAsync(link,token));
        }

        // GET: StatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // PStatusT: StatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateStatusDto createStatusDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createStatusDto);
                await Request<StatusDto>.PostAsync(APILinks.STATUS_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createStatusDto);
        }

        // GET: StatusController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.STATUS_URL + "/" + id;
            return View(await Request<UpdateStatusDto>.GetAsync(link, token));
        }

        // PStatusT: StatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateStatusDto updateStatusDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateStatusDto);
                await Request<UpdateStatusDto>.PutAsync(APILinks.STATUS_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updateStatusDto);
        }

        // GET: StatusController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.STATUS_URL + "/" + id;
            return View(await Request<StatusDto>.GetAsync(link, token));
        }

        // PStatusT: StatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, StatusDto StatustDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<StatusDto>.DeleteAsync(APILinks.STATUS_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(StatustDto);
        }
    }
}
