using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameHeaven.Areas.Admin.Controllers
{
    public class FranchiseController : Controller
    {
        // GET: FranchiseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FranchiseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FranchiseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FranchiseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FranchiseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FranchiseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FranchiseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FranchiseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
