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
    public class AlimentacionesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: Alimentaciones
        public ActionResult Index()
        {
            return View(_UnityOfWork.Alimentaciones.ToList());
        }

        // GET: Alimentaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = _UnityOfWork.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alimentaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlimentacionId,NombreAlimentacion,CategoriaAlimentacion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Alimentaciones.Add(alimentacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alimentacion);
        }

        // GET: Alimentaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = _UnityOfWork.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlimentacionId,NombreAlimentacion,CategoriaAlimentacion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(alimentacion).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = _UnityOfWork.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alimentacion alimentacion = _UnityOfWork.Alimentaciones.Find(id);
            _UnityOfWork.Alimentaciones.Remove(alimentacion);
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
