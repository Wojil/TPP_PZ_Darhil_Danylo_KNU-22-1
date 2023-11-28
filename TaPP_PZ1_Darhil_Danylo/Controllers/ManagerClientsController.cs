using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPP_PZ_Darhil_Danylo.Controllers
{
    public class ManagerClientsController : Controller
    {
        // GET: ManagerClientsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerClientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerClientsController/Create
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

        // GET: ManagerClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerClientsController/Edit/5
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

        // GET: ManagerClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerClientsController/Delete/5
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
