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
    public class CotizacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cotizacions
        public ActionResult Index()
        {
            return View(db.Cotizacions.ToList());
        }

        public ActionResult ValidarAdelantos()
        {
            //return View(db.SolCotizacions.ToList());
            return View(db.SolCotizacions.Where(c => c.Estado == "Por Validar").ToList());
        }

        public ActionResult ValidarAdelanto(int? solCotizacionId)
        {
            if (solCotizacionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cotizacion cotizacion= db.Cotizacions.Find(solCotizacionId);
            Cotizacion cotizacion = (from c in db.Cotizacions where c.SolCotizacion.SolCotizacionId == solCotizacionId select c).FirstOrDefault();
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // GET: Cotizacions/Cotizar/5
        public ActionResult Cotizar(int? solCotizacionId)
        {
            if (solCotizacionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolCotizacion solCotizacion = db.SolCotizacions.Find(solCotizacionId);
            if (solCotizacion == null)
            {
                return HttpNotFound();
            }
            Cotizacion cotizacion = new Cotizacion();
            cotizacion.SolCotizacion = solCotizacion;
            if (cotizacion.DetalleCotiacions == null)
            {
                cotizacion.DetalleCotiacions = new List<DetalleCotizacion>()
                {
                    new DetalleCotizacion(),
                    new DetalleCotizacion(),
                    new DetalleCotizacion()
                };
            }
            return View(cotizacion);
        }

        public ActionResult ListaSolCotizacions()
        {
            return RedirectToAction("Index", "SolCotizacions");
        }

        // POST: Cotizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "CotizacionId,Mensaje,Dias,PrecioTotal, SolCotizacion, DetalleCotiacions, SolCotizacion.NombreEmpresa, SolCotizacion.DescripcionDelNegocio, SolCotizacion.Mision, SolCotizacion.Vision, SolCotizacion.Direccion, SolCotizacion.CorreoDeEmpresa, SolCotizacion.TelefonoDeEmpresa, SolCotizacion.NumeroPaginas, SolCotizacion.PaginaConCatalogo, SolCotizacion.CarritoDeCompras, SolCotizacion.TipoWeb, SolCotizacion.DetallesAdicionales")] Cotizacion model)
        {
            if (ModelState.IsValid)
            {
                model.FechaCotizacion = DateTime.Now;
                SolCotizacion solCotizacion = (from sc in db.SolCotizacions where sc.SolCotizacionId == model.SolCotizacion.SolCotizacionId select sc).FirstOrDefault(); ;
                solCotizacion.Estado = "Cotizada";
                model.PrecioTotal = 0;
                foreach (DetalleCotizacion detalle in model.DetalleCotiacions)
                {
                    model.PrecioTotal += detalle.PrecioDetalle;
                }
                model.SolCotizacion = solCotizacion;
                db.Cotizacions.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "SolCotizacions");
            }

            return View(model);
        }

        // GET: Cotizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Mensaje,Dias,PrecioTotal")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            db.Cotizacions.Remove(cotizacion);
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
