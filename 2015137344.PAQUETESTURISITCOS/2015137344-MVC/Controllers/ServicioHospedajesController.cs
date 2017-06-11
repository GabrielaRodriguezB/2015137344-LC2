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
    public class ServicioHospedajesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: ServicioHospedajes
        public ActionResult Index()
        {
            return View(_UnityOfWork.ServiciosHospedaje.ToList());
        }

        // GET: ServicioHospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioHospedaje servicioHospedaje = _UnityOfWork.ServiciosHospedaje.Find(id);
            if (servicioHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(servicioHospedaje);
        }

        // GET: ServicioHospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioHospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicioHospedajeId,NomServicioHospedaje")] ServicioHospedaje servicioHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.ServiciosHospedaje.Add(servicioHospedaje);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicioHospedaje);
        }

        // GET: ServicioHospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioHospedaje servicioHospedaje = _UnityOfWork.ServiciosHospedaje.Find(id);
            if (servicioHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(servicioHospedaje);
        }

        // POST: ServicioHospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicioHospedajeId,NomServicioHospedaje")] ServicioHospedaje servicioHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(servicioHospedaje).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicioHospedaje);
        }

        // GET: ServicioHospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioHospedaje servicioHospedaje = _UnityOfWork.ServiciosHospedaje.Find(id);
            if (servicioHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(servicioHospedaje);
        }

        // POST: ServicioHospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioHospedaje servicioHospedaje = _UnityOfWork.ServiciosHospedaje.Find(id);
            _UnityOfWork.ServiciosHospedaje.Remove(servicioHospedaje);
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
