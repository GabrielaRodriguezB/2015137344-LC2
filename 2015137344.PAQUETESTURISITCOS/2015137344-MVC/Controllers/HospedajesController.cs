using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2015137344_ENT.Entities;
using _2015137344_PER;

namespace _2015137344_MVC.Controllers
{
    public class HospedajesController : Controller
    {
        private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();

        // GET: Hospedajes
        public ActionResult Index()
        {
            return View(db.Hospedajes.ToList());
        }

        // GET: Hospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedajes.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // GET: Hospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HospedajeId,NombreHospedaje,TipoHospedaje,CalificacionHospedaje,CategoriaHospedaje,ServicioHospedaje")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                db.Hospedajes.Add(hospedaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospedaje);
        }

        // GET: Hospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedajes.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // POST: Hospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HospedajeId,NombreHospedaje,TipoHospedaje,CalificacionHospedaje,CategoriaHospedaje,ServicioHospedaje")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospedaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospedaje);
        }

        // GET: Hospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedaje hospedaje = db.Hospedajes.Find(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // POST: Hospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospedaje hospedaje = db.Hospedajes.Find(id);
            db.Hospedajes.Remove(hospedaje);
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
