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
    public class TipoComprobantesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: TipoComprobantes
        public ActionResult Index()
        {
            return View(_UnityOfWork.TiposComprobante.ToList());
        }

        // GET: TipoComprobantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComprobante tipoComprobante = _UnityOfWork.TiposComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // GET: TipoComprobantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoComprobantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoComprobanteId,NomTipoComprobante")] TipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TiposComprobante.Add(tipoComprobante);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoComprobante);
        }

        // GET: TipoComprobantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComprobante tipoComprobante = _UnityOfWork.TiposComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // POST: TipoComprobantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoComprobanteId,NomTipoComprobante")] TipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(tipoComprobante).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoComprobante);
        }

        // GET: TipoComprobantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoComprobante tipoComprobante = _UnityOfWork.TiposComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // POST: TipoComprobantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoComprobante tipoComprobante = _UnityOfWork.TiposComprobante.Find(id);
            _UnityOfWork.TiposComprobante.Remove(tipoComprobante);
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
