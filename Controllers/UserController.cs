using DS_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DS_System.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios usuarios)
        {
            string mensaje = "";
            if (ModelState.IsValid)
            {
                if (Functions.LoginFuncion.ValidarLogin(usuarios))
                {
                    Session["SessionAdmin"] = usuarios.Email;
                    return RedirectToAction("Index", "Productos");
                }
                else
                {
                    mensaje = "Usuario o contraseña incorrectos";
                }
                
            }
            ViewBag.Message=mensaje;
            return View("Login");
        }

    }
}