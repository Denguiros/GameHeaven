using GameHeaven.Dtos.OsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class OsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Oss = await Request<List<OsDto>>.GetAsync(APILinks.OS_URL, token);
            return View(Oss);
        }

        // GET: OsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.OS_URL + "/" + id;
            return View(await Request<OsDto>.GetAsync(link,token));
        }

        // GET: OsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOsDto createOsDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createOsDto);
                await Request<OsDto>.PostAsync(APILinks.OS_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createOsDto);
        }

        // GET: OsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.OS_URL + "/" + id;
            return View(await Request<UpdateOsDto>.GetAsync(link, token));
        }

        // POST: OsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateOsDto updateOsDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateOsDto);
                await Request<UpdateOsDto>.PutAsync(APILinks.OS_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updateOsDto);
        }

        // GET: OsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.OS_URL + "/" + id;
            return View(await Request<OsDto>.GetAsync(link, token));
        }

        // POST: OsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, OsDto OstDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<OsDto>.DeleteAsync(APILinks.OS_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(OstDto);
        }
    }
}
