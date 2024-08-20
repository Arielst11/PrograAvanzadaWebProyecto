using FrontEnd.ApiModels;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ClaseController : Controller
    {
        IClaseHelper ClaseHelper;

        public ClaseController(IClaseHelper claseHelper)
        {
            ClaseHelper = claseHelper;
        }

        // GET: ClaseController
        public ActionResult Index()
        {
            return View(ClaseHelper.GetClases());
        }

        // GET: ClaseController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            ClaseHelper.Token = HttpContext.Session.GetString("token");
            ClaseViewModel clase = ClaseHelper.GetClase(id);
            return View(clase);
        }

        // GET: ClaseController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ClaseViewModel clase)
        {
            try
            {
                ClaseHelper.Token = HttpContext.Session.GetString("token");
                _ = ClaseHelper.Add(clase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaseController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)

        {
            ClaseHelper.Token = HttpContext.Session.GetString("token");
            ClaseViewModel clase = ClaseHelper.GetClase(id);
            return View(clase);
        }

        // POST: ClaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(ClaseViewModel clase)
        {
            try
            {
                ClaseHelper.Token = HttpContext.Session.GetString("token");
                _ = ClaseHelper.Update(clase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaseController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ClaseHelper.Token = HttpContext.Session.GetString("token");
            ClaseViewModel clase = ClaseHelper.GetClase(id);
            return View(clase);
        }

        // POST: ClaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(ClaseViewModel clase)
        {
            try
            {
                ClaseHelper.Token = HttpContext.Session.GetString("token");
                _ = ClaseHelper.Remove(clase.IdClase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
