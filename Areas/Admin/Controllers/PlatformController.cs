using GameHeaven.Dtos.PlatformDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class PlatformController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Platforms = await Request<List<PlatformDto>>.GetAsync(APILinks.PLATFORM_URL, token);
            return View(Platforms);
        }

        // GET: PlatformController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.PLATFORM_URL + "/" + id;
            return View(await Request<PlatformDto>.GetAsync(link,token));
        }

        // GET: PlatformController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatformController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePlatformDto createPlatformDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createPlatformDto);
                await Request<PlatformDto>.PostAsync(APILinks.PLATFORM_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createPlatformDto);
        }

        // GET: PlatformController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.PLATFORM_URL + "/" + id;
            return View(await Request<UpdatePlatformDto>.GetAsync(link, token));
        }

        // POST: PlatformController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdatePlatformDto updatePlatformDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updatePlatformDto);
                await Request<UpdatePlatformDto>.PutAsync(APILinks.PLATFORM_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updatePlatformDto);
        }

        // GET: PlatformController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.PLATFORM_URL + "/" + id;
            return View(await Request<PlatformDto>.GetAsync(link, token));
        }

        // POST: PlatformController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PlatformDto PlatformtDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<PlatformDto>.DeleteAsync(APILinks.PLATFORM_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(PlatformtDto);
        }
    }
}
