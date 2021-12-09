using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlexDigital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Inicio");
        }

        [Authorize]
        public ActionResult Inicio()
        {
            if (User.IsInRole("Cliente"))
            {
                return RedirectToAction("MisSolicitudes", "SolCotizacions");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "SolCotizacions");
            }
            else if (User.IsInRole("Trabajador"))
            {
                return RedirectToAction("MisProyectosTrabajador", "Proyectoes");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}