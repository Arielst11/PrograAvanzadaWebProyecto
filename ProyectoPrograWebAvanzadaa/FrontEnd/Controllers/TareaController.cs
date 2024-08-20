using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TareaController : Controller
    {
        ITareaHelper TareaHelper;

        public TareaController(ITareaHelper tareaHelper)
        {
            TareaHelper = tareaHelper;
        }

        // GET: TareaController
        public ActionResult Index()
        {
            return View(TareaHelper.GetTareas());
        }

        // GET: TareaController/Details/5
        public ActionResult Details(int id)
        {
            TareaHelper.Token = HttpContext.Session.GetString("token");
            TareaViewModel tarea = TareaHelper.GetTarea(id);
            return View(tarea);
        }

        // GET: TareaController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TareaController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TareaViewModel tarea)
        {
            try
            {
                TareaHelper.Token = HttpContext.Session.GetString("token");
                _ = TareaHelper.Add(tarea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareaController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            TareaHelper.Token = HttpContext.Session.GetString("token");
            TareaViewModel tarea = TareaHelper.GetTarea(id);
            return View(tarea);
        }

        // POST: TareaController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TareaViewModel tarea)
        {
            try
            {
                TareaHelper.Token = HttpContext.Session.GetString("token");
                _ = TareaHelper.Update(tarea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TareaController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            TareaHelper.Token = HttpContext.Session.GetString("token");
            TareaViewModel tarea = TareaHelper.GetTarea(id);
            return View(tarea);
        }

        // POST: TareaController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TareaViewModel tarea)
        {
            try
            {
                TareaHelper.Token = HttpContext.Session.GetString("token");
                _ = TareaHelper.Remove(tarea.IdTarea);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
