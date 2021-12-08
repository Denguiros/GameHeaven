using GameHeaven.Dtos.CPUDtos;
using GameHeavenAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(Roles.Admin))]
    public class CpuController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var cpus = await Request<List<CPUDto>>.GetAsync(APILinks.CPU_URL, token);
            return View(cpus);
            //return View(new List<CPUDto>());
        }

        // GET: CpuController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.CPU_URL + "/" + id;
            return View(await Request<CPUDto>.GetAsync(link,token));
        }

        // GET: CpuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CpuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCPUDto createCPUDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createCPUDto);
                await Request<CPUDto>.PostAsync(APILinks.CPU_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createCPUDto);
        }

        // GET: CpuController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.CPU_URL + "/" + id;
            return View(await Request<UpdateCPUDto>.GetAsync(link, token));
        }

        // POST: CpuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateCPUDto updateCPUDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateCPUDto);
                await Request<UpdateCPUDto>.PutAsync(APILinks.CPU_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updateCPUDto);
        }

        // GET: CpuController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.CPU_URL + "/" + id;
            return View(await Request<CPUDto>.GetAsync(link, token));
        }

        // POST: CpuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CPUDto cputDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<CPUDto>.DeleteAsync(APILinks.CPU_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(cputDto);
        }
    }
}
