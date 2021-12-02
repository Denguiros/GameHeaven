using GameHeaven.Dtos.DirectXDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class DirectXController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var DirectXs = await Request<List<DirectXDto>>.GetAsync(APILinks.DIRECTX_URL, token);
            return View(DirectXs);
            //return View(new List<DirectXDto>());
        }

        // GET: DirectXController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.DIRECTX_URL + "/" + id;
            return View(await Request<DirectXDto>.GetAsync(link,token));
        }

        // GET: DirectXController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectXController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDirectXDto createDirectXDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createDirectXDto);
                await Request<DirectXDto>.PostAsync(APILinks.DIRECTX_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createDirectXDto);
        }

        // GET: DirectXController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.DIRECTX_URL + "/" + id;
            return View(await Request<UpdateDirectXDto>.GetAsync(link, token));
        }

        // POST: DirectXController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateDirectXDto updateDirectXDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateDirectXDto);
                await Request<UpdateDirectXDto>.PutAsync(APILinks.DIRECTX_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updateDirectXDto);
        }

        // GET: DirectXController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.DIRECTX_URL + "/" + id;
            return View(await Request<DirectXDto>.GetAsync(link, token));
        }

        // POST: DirectXController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DirectXDto DirectXtDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<DirectXDto>.DeleteAsync(APILinks.DIRECTX_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(DirectXtDto);
        }
    }
}
