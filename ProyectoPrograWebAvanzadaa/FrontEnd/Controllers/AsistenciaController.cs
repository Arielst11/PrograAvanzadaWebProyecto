using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class AsistenciaController : Controller
    {

        IAsistenciaHelper AsistenciaHelper;

        public AsistenciaController(IAsistenciaHelper asistenciaHelper)
        {
            AsistenciaHelper = asistenciaHelper;
        }

        // GET: AsistenciaController
        public ActionResult Index()
        {
            return View(AsistenciaHelper.GetAsistencias());
        }

        // GET: AsistenciaController/Details/5
        public ActionResult Details(int id)
        {
            AsistenciaViewModel asistencia = AsistenciaHelper.GetAsistencia(id);
            return View(asistencia);
        }

        // GET: AsistenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsistenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsistenciaViewModel asistencia)
        {
            try
            {
                _=AsistenciaHelper.Add(asistencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AsistenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            AsistenciaViewModel asistencia = AsistenciaHelper.GetAsistencia(id);
            return View(asistencia);
        }

        // POST: AsistenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsistenciaViewModel asistencia)
        {
            try
            {
                _ = AsistenciaHelper.Update(asistencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AsistenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            AsistenciaViewModel asistencia = AsistenciaHelper.GetAsistencia(id);
            return View(asistencia);
        }

        // POST: AsistenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AsistenciaViewModel asistencia)
        {
            try
            {
                _ = AsistenciaHelper.Remove(asistencia.IdAsistencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
