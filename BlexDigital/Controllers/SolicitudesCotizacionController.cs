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
    public class SolicitudesCotizacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitudesCotizacion
        public ActionResult Index()
        {
            return View(db.SolicitudesCotizacion.ToList());
        }

        // GET: SolicitudesCotizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCotizacion solicitudCotizacion = db.SolicitudesCotizacion.Find(id);
            if (solicitudCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCotizacion);
        }

        // GET: SolicitudesCotizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudesCotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreEmpresa,Correo,Celular,NumeroPaginas,CarritoDeCompras")] SolicitudCotizacion solicitudCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudesCotizacion.Add(solicitudCotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitudCotizacion);
        }

        // GET: SolicitudesCotizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCotizacion solicitudCotizacion = db.SolicitudesCotizacion.Find(id);
            if (solicitudCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCotizacion);
        }

        // POST: SolicitudesCotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreEmpresa,Correo,Celular,NumeroPaginas,CarritoDeCompras")] SolicitudCotizacion solicitudCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudCotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitudCotizacion);
        }

        // GET: SolicitudesCotizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCotizacion solicitudCotizacion = db.SolicitudesCotizacion.Find(id);
            if (solicitudCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCotizacion);
        }

        // POST: SolicitudesCotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudCotizacion solicitudCotizacion = db.SolicitudesCotizacion.Find(id);
            db.SolicitudesCotizacion.Remove(solicitudCotizacion);
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
