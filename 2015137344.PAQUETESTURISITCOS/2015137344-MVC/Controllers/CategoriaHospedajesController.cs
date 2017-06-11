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
    public class CategoriaHospedajesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: CategoriaHospedajes
        public ActionResult Index()
        {
            return View(_UnityOfWork.CategoriasHospedaje.ToList());
        }

        // GET: CategoriaHospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaHospedaje categoriaHospedaje = _UnityOfWork.CategoriasHospedaje.Find(id);
            if (categoriaHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(categoriaHospedaje);
        }

        // GET: CategoriaHospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaHospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaHospedajeId,NomCategoriaHospedaje")] CategoriaHospedaje categoriaHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CategoriasHospedaje.Add(categoriaHospedaje);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaHospedaje);
        }

        // GET: CategoriaHospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaHospedaje categoriaHospedaje = _UnityOfWork.CategoriasHospedaje.Find(id);
            if (categoriaHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(categoriaHospedaje);
        }

        // POST: CategoriaHospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaHospedajeId,NomCategoriaHospedaje")] CategoriaHospedaje categoriaHospedaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(categoriaHospedaje).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaHospedaje);
        }

        // GET: CategoriaHospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaHospedaje categoriaHospedaje = _UnityOfWork.CategoriasHospedaje.Find(id);
            if (categoriaHospedaje == null)
            {
                return HttpNotFound();
            }
            return View(categoriaHospedaje);
        }

        // POST: CategoriaHospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaHospedaje categoriaHospedaje = _UnityOfWork.CategoriasHospedaje.Find(id);
            _UnityOfWork.CategoriasHospedaje.Remove(categoriaHospedaje);
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
