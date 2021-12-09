using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlexDigital.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlexDigital.Controllers
{
    public class ProyectoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proyectoes
        public ActionResult Index()
        {
            List<Proyecto> proyectos = db.Proyectos.Include(p => p.Cotizacion).ToList();
            return View(proyectos);
        }

        // GET: Proyectoes/MisProyectosCliente
        public ActionResult MisProyectosCliente()
        {
            string userName = HttpContext.User.Identity.Name;
            return View(db.Proyectos.Where(x => x.Cliente.UserName == userName).ToList());
        }

        // GET: Proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = (from c in db.Proyectos where c.ProyectoId == id select c).Include(c => c.Cotizacion).FirstOrDefault();
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyectoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProyectoId,FechaCreacion")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyectos.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }
        

        // GET: Proyectoes/Edit/5
        public ActionResult AsignarDisenador(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            AsignarDiseñadorViewModel viewModel = new AsignarDiseñadorViewModel();
            viewModel.Proyecto = proyecto;
            //string[] trabajadoresNames = Roles.GetUsersInRole("Trabajador");
            IdentityRole roleTrabajador = (from r in db.Roles where r.Name == "Trabajador" select r).FirstOrDefault();
            var roleUserIdsQuery = from role in db.Roles
                                   where role.Name == "Trabajador"
                                   from user in role.Users
                                   select user.UserId;
            var users = db.Users.Where(u => roleUserIdsQuery.Contains(u.Id)).ToList();
            viewModel.Trabajadores = users;
            return View(viewModel);
        }

        public ActionResult Asignar(string workerId, int? proyectoId)
        {
            if (workerId == null || proyectoId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser worker = db.Users.Find(workerId);
            if (worker == null)
            {
                return HttpNotFound();
            }
            Proyecto proyecto = db.Proyectos.Find(proyectoId);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            proyecto.Trabajador = worker;
            proyecto.Estado = "Asignado";
            db.Proyectos.Add(proyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Proyectoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProyectoId,FechaCreacion")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyectos.Find(id);
            db.Proyectos.Remove(proyecto);
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
