using GameHeaven.Dtos.GPUDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class GPUController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var GPUs = await Request<List<GPUDto>>.GetAsync(APILinks.GPU_URL, token);
            return View(GPUs);
            //return View(new List<GPUDto>());
        }

        // GET: GPUController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GPU_URL + "/" + id;
            return View(await Request<GPUDto>.GetAsync(link, token));
        }

        // GET: GPUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGPUDto createGPUDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createGPUDto);
                await Request<GPUDto>.PostAsync(APILinks.GPU_URL, jsonObject, token: token);
                return RedirectToAction("Index");
            }
            return View(createGPUDto);
        }

        // GET: GPUController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GPU_URL + "/" + id;
            return View(await Request<UpdateGPUDto>.GetAsync(link, token));
        }

        // POST: GPUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateGPUDto updateGPUDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateGPUDto);
                await Request<UpdateGPUDto>.PutAsync(APILinks.GPU_URL + "/" + id, jsonObject, token: token);
                return RedirectToAction("Index");
            }
            return View(updateGPUDto);
        }

        // GET: GPUController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GPU_URL + "/" + id;
            return View(await Request<GPUDto>.GetAsync(link, token));
        }

        // POST: GPUController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GPUDto GPUtDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<GPUDto>.DeleteAsync(APILinks.GPU_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(GPUtDto);
        }
    }
}
