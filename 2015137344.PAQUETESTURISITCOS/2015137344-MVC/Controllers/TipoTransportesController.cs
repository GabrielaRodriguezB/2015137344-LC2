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
    public class TipoTransportesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: TipoTransportes
        public ActionResult Index()
        {
            return View(_UnityOfWork.TiposTransporte.ToList());
        }

        // GET: TipoTransportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransporte tipoTransporte = _UnityOfWork.TiposTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTransportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoTransporteId,NomTipoTransporte")] TipoTransporte tipoTransporte)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TiposTransporte.Add(tipoTransporte);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransporte tipoTransporte = _UnityOfWork.TiposTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // POST: TipoTransportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoTransporteId,NomTipoTransporte")] TipoTransporte tipoTransporte)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(tipoTransporte).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransporte tipoTransporte = _UnityOfWork.TiposTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // POST: TipoTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTransporte tipoTransporte = _UnityOfWork.TiposTransporte.Find(id);
            _UnityOfWork.TiposTransporte.Remove(tipoTransporte);
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
