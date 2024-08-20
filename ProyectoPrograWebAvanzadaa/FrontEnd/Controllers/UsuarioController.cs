using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioHelper UsuarioHelper;

        public UsuarioController(IUsuarioHelper usuarioHelper)
        {
            UsuarioHelper = usuarioHelper;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(UsuarioHelper.GetUsuarios());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(string id)
        {
            UsuarioViewModel usuario = UsuarioHelper.GetUsuario(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                _ = UsuarioHelper.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(string id)
        {
            UsuarioViewModel usuario = UsuarioHelper.GetUsuario(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                _ = UsuarioHelper.Update(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(string id)
        {
            UsuarioViewModel usuario = UsuarioHelper.GetUsuario(id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                _ = UsuarioHelper.Remove(usuario.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
