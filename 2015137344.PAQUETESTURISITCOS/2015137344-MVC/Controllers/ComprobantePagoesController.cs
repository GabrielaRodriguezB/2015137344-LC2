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
    public class ComprobantePagoesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: ComprobantePagoes
        public ActionResult Index()
        {
            var comprobantesPago = _UnityOfWork.ComprobantesPago.Include(c => c.TipoComprobante).Include(c => c.VentaPaquete);
            return View(comprobantesPago.ToList());
        }

        // GET: ComprobantePagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantesPago.Find(id);
            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            return View(comprobantePago);
        }

        // GET: ComprobantePagoes/Create
        public ActionResult Create()
        {
            ViewBag.TipoComprobanteId = new SelectList(_UnityOfWork.TiposComprobante, "TipoComprobanteId", "NomTipoComprobante");
            ViewBag.ComprobantePagoId = new SelectList(_UnityOfWork.VentasPaquetes, "VentaPaqueteId", "VentaPaqueteId");
            return View();
        }

        // POST: ComprobantePagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprobantePagoId,NumComprobantePago,TipoComprobanteId,VentaPaqueteId")] ComprobantePago comprobantePago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.ComprobantesPago.Add(comprobantePago);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoComprobanteId = new SelectList(_UnityOfWork.TiposComprobante, "TipoComprobanteId", "NomTipoComprobante", comprobantePago.TipoComprobanteId);
            ViewBag.ComprobantePagoId = new SelectList(_UnityOfWork.VentasPaquetes, "VentaPaqueteId", "VentaPaqueteId", comprobantePago.ComprobantePagoId);
            return View(comprobantePago);
        }

        // GET: ComprobantePagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantesPago.Find(id);
            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoComprobanteId = new SelectList(_UnityOfWork.TiposComprobante, "TipoComprobanteId", "NomTipoComprobante", comprobantePago.TipoComprobanteId);
            ViewBag.ComprobantePagoId = new SelectList(_UnityOfWork.VentasPaquetes, "VentaPaqueteId", "VentaPaqueteId", comprobantePago.ComprobantePagoId);
            return View(comprobantePago);
        }

        // POST: ComprobantePagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprobantePagoId,NumComprobantePago,TipoComprobanteId,VentaPaqueteId")] ComprobantePago comprobantePago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(comprobantePago).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoComprobanteId = new SelectList(_UnityOfWork.TiposComprobante, "TipoComprobanteId", "NomTipoComprobante", comprobantePago.TipoComprobanteId);
            ViewBag.ComprobantePagoId = new SelectList(_UnityOfWork.VentasPaquetes, "VentaPaqueteId", "VentaPaqueteId", comprobantePago.ComprobantePagoId);
            return View(comprobantePago);
        }

        // GET: ComprobantePagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantesPago.Find(id);
            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            return View(comprobantePago);
        }

        // POST: ComprobantePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantesPago.Find(id);
            _UnityOfWork.ComprobantesPago.Remove(comprobantePago);
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
