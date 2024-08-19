using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TipoUsuarioController : Controller
    {
        ITipoUsuarioHelper TipoUsuarioHelper;

        public TipoUsuarioController(ITipoUsuarioHelper tipoUsuarioHelper)
        {
            TipoUsuarioHelper = tipoUsuarioHelper;
        }

        // GET: TipoUsuarioController
        public ActionResult Index()
        {
            return View(TipoUsuarioHelper.GetTipoUsuarios());
        }

        // GET: TipoUsuarioController/Details/5
        public ActionResult Details(int id)
        {
            TipoUsuarioViewModel tipoUsuario = TipoUsuarioHelper.GetTipoUsuario(id);
            return View(tipoUsuario);
        }

        // GET: TipoUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoUsuarioViewModel tipoUsuario)
        {
            try
            {
                _ = TipoUsuarioHelper.Add(tipoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoUsuarioViewModel tipoUsuario = TipoUsuarioHelper.GetTipoUsuario(id);
            return View(tipoUsuario);
        }

        // POST: TipoUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoUsuarioViewModel tipoUsuario)
        {
            try
            {
                _ = TipoUsuarioHelper.Update(tipoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoUsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            TipoUsuarioViewModel tipoUsuario = TipoUsuarioHelper.GetTipoUsuario(id);
            return View(tipoUsuario);
        }

        // POST: TipoUsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoUsuarioViewModel tipoUsuario)
        {
            try
            {
                _ = TipoUsuarioHelper.Remove(tipoUsuario.IdTipoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
