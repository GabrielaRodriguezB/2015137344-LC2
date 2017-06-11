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
    public class MedioPagoesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: MedioPagoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.MediosPago.ToList());
        }

        // GET: MedioPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Find(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // GET: MedioPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedioPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedioPagoId,NomMedioPago")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.MediosPago.Add(medioPago);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medioPago);
        }

        // GET: MedioPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Find(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // POST: MedioPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedioPagoId,NomMedioPago")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(medioPago).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medioPago);
        }

        // GET: MedioPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Find(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // POST: MedioPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedioPago medioPago = _UnityOfWork.MediosPago.Find(id);
            _UnityOfWork.MediosPago.Remove(medioPago);
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
