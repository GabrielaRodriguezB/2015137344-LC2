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
    public class ServicioTuristicoes1Controller : Controller
    {
        private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();

        // GET: ServicioTuristicoes1
        public ActionResult Index()
        {
            return View(db.ServiciosTuristicos.ToList());
        }

        // GET: ServicioTuristicoes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = db.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioTuristicoes1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicioTuristicoId,PrecioServicioTuristico")] ServicioTuristico servicioTuristico)
        {
            if (ModelState.IsValid)
            {
                db.ServiciosTuristicos.Add(servicioTuristico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = db.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // POST: ServicioTuristicoes1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicioTuristicoId,PrecioServicioTuristico")] ServicioTuristico servicioTuristico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicioTuristico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = db.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // POST: ServicioTuristicoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioTuristico servicioTuristico = db.ServiciosTuristicos.Find(id);
            db.ServiciosTuristicos.Remove(servicioTuristico);
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
