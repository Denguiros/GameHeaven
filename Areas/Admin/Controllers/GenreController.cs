using GameHeaven.Dtos.GenreDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameHeaven.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var Genres = await Request<List<GenreDto>>.GetAsync(APILinks.GENRE_URL, token);
            return View(Genres);
            //return View(new List<GenreDto>());
        }

        // GET: GenreController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GENRE_URL + "/" + id;
            return View(await Request<GenreDto>.GetAsync(link,token));
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGenreDto createGenreDto)
        {
            if (ModelState.IsValid)
            {
            var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(createGenreDto);
                await Request<GenreDto>.PostAsync(APILinks.GENRE_URL, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(createGenreDto);
        }

        // GET: GenreController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GENRE_URL + "/" + id;
            return View(await Request<UpdateGenreDto>.GetAsync(link, token));
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateGenreDto updateGenreDto)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                string jsonObject = JsonConvert.SerializeObject(updateGenreDto);
                await Request<UpdateGenreDto>.PutAsync(APILinks.GENRE_URL + "/" + id, jsonObject,token: token);
                return RedirectToAction("Index");
            }
            return View(updateGenreDto);
        }

        // GET: GenreController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GENRE_URL + "/" + id;
            return View(await Request<GenreDto>.GetAsync(link, token));
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GenreDto GenretDto)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<GenreDto>.DeleteAsync(APILinks.GENRE_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(GenretDto);
        }
    }
}
