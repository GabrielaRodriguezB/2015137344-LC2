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
    public class ServicioTuristicoesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: ServicioTuristicoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.ServiciosTuristicos.ToList());
        }

        // GET: ServicioTuristicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = _UnityOfWork.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioTuristicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicioTuristicoId,PrecioServicioTuristico")] ServicioTuristico servicioTuristico)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.ServiciosTuristicos.Add(servicioTuristico);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = _UnityOfWork.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // POST: ServicioTuristicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicioTuristicoId,PrecioServicioTuristico")] ServicioTuristico servicioTuristico)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(servicioTuristico).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicioTuristico);
        }

        // GET: ServicioTuristicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioTuristico servicioTuristico = _UnityOfWork.ServiciosTuristicos.Find(id);
            if (servicioTuristico == null)
            {
                return HttpNotFound();
            }
            return View(servicioTuristico);
        }

        // POST: ServicioTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioTuristico servicioTuristico = _UnityOfWork.ServiciosTuristicos.Find(id);
            _UnityOfWork.ServiciosTuristicos.Remove(servicioTuristico);
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
