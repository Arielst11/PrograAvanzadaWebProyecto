using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class AsistenciasController : Controller
    {
        // GET: AsistenciasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AsistenciasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsistenciasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsistenciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsistenciasViewModel asistencias)
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

        // GET: AsistenciasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsistenciasController/Edit/5
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

        // GET: AsistenciasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsistenciasController/Delete/5
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
