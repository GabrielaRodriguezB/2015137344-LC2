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
    public class TipoHospedajesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: TipoHospedajes
        public ActionResult Index()
        {
            return View(_UnityOfWork.TiposHospedaje.ToList());
        }

        // GET: TipoHospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHospedaje tipoHospedaje = _UnityOfWork.TiposHospedaje.Find(id);
            if (tipoHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(tipoHospedaje);
        }

        // GET: TipoHospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoHospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoHospedajeId,NomTipoHospedaje")] TipoHospedaje tipoHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TiposHospedaje.Add(tipoHospedaje);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoHospedaje);
        }

        // GET: TipoHospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHospedaje tipoHospedaje = _UnityOfWork.TiposHospedaje.Find(id);
            if (tipoHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(tipoHospedaje);
        }

        // POST: TipoHospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoHospedajeId,NomTipoHospedaje")] TipoHospedaje tipoHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(tipoHospedaje).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoHospedaje);
        }

        // GET: TipoHospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHospedaje tipoHospedaje = _UnityOfWork.TiposHospedaje.Find(id);
            if (tipoHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(tipoHospedaje);
        }

        // POST: TipoHospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoHospedaje tipoHospedaje = _UnityOfWork.TiposHospedaje.Find(id);
            _UnityOfWork.TiposHospedaje.Remove(tipoHospedaje);
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
