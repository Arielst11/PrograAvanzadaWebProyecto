using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class NotaController : Controller
    {
        INotaHelper NotaHelper;

        public NotaController(INotaHelper notaHelper)
        {
            NotaHelper = notaHelper;
        }

        // GET: NotaController
        public ActionResult Index()
        {
            try
            {
                var notas = NotaHelper.GetNotas(); // Obtiene las notas
                return View(notas); // Devuelve la vista con las notas
            }
            catch (UnauthorizedAccessException ex)
            {
                // Maneja el caso en que el usuario no tiene permiso
                // Puedes redirigir a una vista de error o mostrar un mensaje
                TempData["ErrorMessage"] = "No tienes permiso para acceder a esta información.";
                return RedirectToAction("AccessDenied", "Home");
            }
            catch (Exception ex)
            {
                // Maneja otras posibles excepciones
                // Loguea el error o muestra un mensaje general
                TempData["ErrorMessage"] = "Ocurrió un error inesperado.";
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: NotaController/Details/5
        public ActionResult Details(int id)
        {
            NotaViewModel nota = NotaHelper.GetNota(id);
            return View(nota);
        }

        // GET: NotaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotaViewModel nota)
        {
            try
            {
                _ = NotaHelper.Add(nota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotaController/Edit/5
        public ActionResult Edit(int id)
        {
            NotaViewModel nota = NotaHelper.GetNota(id);
            return View(nota);
        }

        // POST: NotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotaViewModel nota)
        {
            try
            {
                _ = NotaHelper.Update(nota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotaController/Delete/5
        public ActionResult Delete(int id)
        {
            NotaViewModel nota = NotaHelper.GetNota(id);
            return View(nota);
        }

        // POST: NotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NotaViewModel nota)
        {
            try
            {
                _ = NotaHelper.Remove(nota.IdNota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
