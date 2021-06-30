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
    public class DetalleCotizacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetalleCotizacions
        public ActionResult Index()
        {
            return View(db.DetalleCotizacions.ToList());
        }

        // GET: DetalleCotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacions.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleCotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalleCotizacionId,NombreDetalle,PrecioDetalle")] DetalleCotizacion detalleCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCotizacions.Add(detalleCotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacions.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacion);
        }

        // POST: DetalleCotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalleCotizacionId,NombreDetalle,PrecioDetalle")] DetalleCotizacion detalleCotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleCotizacion);
        }

        // GET: DetalleCotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacions.Find(id);
            if (detalleCotizacion == null)
            {
                return HttpNotFound();
            }
            return View(detalleCotizacion);
        }

        // POST: DetalleCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCotizacion detalleCotizacion = db.DetalleCotizacions.Find(id);
            db.DetalleCotizacions.Remove(detalleCotizacion);
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
