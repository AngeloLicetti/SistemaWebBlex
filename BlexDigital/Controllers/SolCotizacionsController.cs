using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlexDigital.Models;
using Sistema_de_gestion_comercial_Blex_Digital.Models;

namespace Sistema_de_gestion_comercial_Blex_Digital.Controllers
{
    public class SolCotizacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolCotizacions
        public ActionResult Index()
        {
            return View(db.SolCotizacions.ToList());
        }

        // GET: SolCotizacions/MisSolicitudes
        public ActionResult MisSolicitudes()
        {
            string userName = HttpContext.User.Identity.Name;
            return View(db.SolCotizacions.Where(x => x.Cliente.UserName == userName).ToList());
        }

        // GET: SolCotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolCotizacion solCotizacion = db.SolCotizacions.Find(id);
            if (solCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solCotizacion);
        }

        // GET: SolCotizacions/Create
        public ActionResult Create()
        {
            string userName = HttpContext.User.Identity.Name;
            ApplicationUser user = (from u in db.Users where u.UserName == userName select u).FirstOrDefault();
            SolCotizacion solCotizacion = new SolCotizacion();
            solCotizacion.Cliente = user;
            return View(solCotizacion);
        }

        // POST: SolCotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolCotizacionId,NombreEmpresa,DescripcionDelNegocio,Mision,Vision,Direccion,CorreoDeEmpresa,TelefonoDeEmpresa,NumeroPaginas,PaginaConCatalogo,CarritoDeCompras, Cliente")] SolCotizacion solCotizacion)
        {
            if (ModelState.IsValid)
            {
                string userName = HttpContext.User.Identity.Name;
                ApplicationUser user = (from u in db.Users where u.UserName == userName select u).FirstOrDefault();
                user.Dni = solCotizacion.Cliente.Dni;
                user.Nombre = solCotizacion.Cliente.Nombre;
                user.Celular = solCotizacion.Cliente.Celular;
                solCotizacion.Cliente = user;
                solCotizacion.FechaSolicitud = DateTime.Now;
                solCotizacion.Estado = "Pendiente";
                db.SolCotizacions.Add(solCotizacion);
                db.SaveChanges();
                return RedirectToAction("MisSolicitudes");
            }

            return View(solCotizacion);
        }

        // GET: SolCotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolCotizacion solCotizacion = db.SolCotizacions.Find(id);
            if (solCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solCotizacion);
        }

        // GET: SolCotizacions/Cotizar/5
        public ActionResult Cotizar(int? id)
        {
            return RedirectToAction("Cotizar", "Cotizacions", new { solCotizacionId = id });
        }

        // POST: SolCotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolCotizacionId,NombreEmpresa,DescripcionDelNegocio,Mision,Vision,Direccion,CorreoDeEmpresa,TelefonoDeEmpresa,NumeroPaginas,PaginaConCatalogo,CarritoDeCompras,Cliente")] SolCotizacion solCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solCotizacion.Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solCotizacion);
        }

        // GET: SolCotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolCotizacion solCotizacion = db.SolCotizacions.Find(id);
            if (solCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solCotizacion);
        }

        // POST: SolCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolCotizacion solCotizacion = db.SolCotizacions.Find(id);
            db.SolCotizacions.Remove(solCotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
