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
    public class CalificacionHospedajesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: CalificacionHospedajes
        public ActionResult Index()
        {
            return View(_UnityOfWork.CalificacionesHospedaje.ToList());
        }

        // GET: CalificacionHospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalificacionHospedaje calificacionHospedaje = _UnityOfWork.CalificacionesHospedaje.Find(id);
            if (calificacionHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(calificacionHospedaje);
        }

        // GET: CalificacionHospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalificacionHospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalificacionHospedajeId,Calificacion")] CalificacionHospedaje calificacionHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CalificacionesHospedaje.Add(calificacionHospedaje);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calificacionHospedaje);
        }

        // GET: CalificacionHospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalificacionHospedaje calificacionHospedaje = _UnityOfWork.CalificacionesHospedaje.Find(id);
            if (calificacionHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(calificacionHospedaje);
        }

        // POST: CalificacionHospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalificacionHospedajeId,Calificacion")] CalificacionHospedaje calificacionHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(calificacionHospedaje).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calificacionHospedaje);
        }

        // GET: CalificacionHospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalificacionHospedaje calificacionHospedaje = _UnityOfWork.CalificacionesHospedaje.Find(id);
            if (calificacionHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(calificacionHospedaje);
        }

        // POST: CalificacionHospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalificacionHospedaje calificacionHospedaje = _UnityOfWork.CalificacionesHospedaje.Find(id);
            _UnityOfWork.CalificacionesHospedaje.Remove(calificacionHospedaje);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
