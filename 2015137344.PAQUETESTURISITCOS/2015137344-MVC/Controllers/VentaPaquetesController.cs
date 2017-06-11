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
    public class VentaPaquetesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: VentaPaquetes
        public ActionResult Index()
        {
            var ventasPaquetes = _UnityOfWork.VentasPaquetes.Include(v => v.MedioPago);
            return View(ventasPaquetes.ToList());
        }

        // GET: VentaPaquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = _UnityOfWork.VentasPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Create
        public ActionResult Create()
        {
            ViewBag.MedioPagoId = new SelectList(_UnityOfWork.MediosPago, "MedioPagoId", "NomMedioPago");
            return View();
        }

        // POST: VentaPaquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaPaqueteId,MontoAPagar,MedioPagoId,ComprobantePagoId")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.VentasPaquetes.Add(ventaPaquete);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedioPagoId = new SelectList(_UnityOfWork.MediosPago, "MedioPagoId", "NomMedioPago", ventaPaquete.MedioPagoId);
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = _UnityOfWork.VentasPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedioPagoId = new SelectList(_UnityOfWork.MediosPago, "MedioPagoId", "NomMedioPago", ventaPaquete.MedioPagoId);
            return View(ventaPaquete);
        }

        // POST: VentaPaquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaPaqueteId,MontoAPagar,MedioPagoId,ComprobantePagoId")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(ventaPaquete).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedioPagoId = new SelectList(_UnityOfWork.MediosPago, "MedioPagoId", "NomMedioPago", ventaPaquete.MedioPagoId);
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = _UnityOfWork.VentasPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // POST: VentaPaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaPaquete ventaPaquete = _UnityOfWork.VentasPaquetes.Find(id);
            _UnityOfWork.VentasPaquetes.Remove(ventaPaquete);
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
