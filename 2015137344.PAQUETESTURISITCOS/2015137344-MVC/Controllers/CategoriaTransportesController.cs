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
    public class CategoriaTransportesController : Controller
    {
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: CategoriaTransportes
        public ActionResult Index()
        {
            return View(_UnityOfWork.CategoriasTransporte.ToList());
        }

        // GET: CategoriaTransportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTransporte categoriaTransporte = _UnityOfWork.CategoriasTransporte.Find(id);
            if (categoriaTransporte == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTransporte);
        }

        // GET: CategoriaTransportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaTransportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaTransporteId,NomCategoriaTransporte")] CategoriaTransporte categoriaTransporte)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CategoriasTransporte.Add(categoriaTransporte);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaTransporte);
        }

        // GET: CategoriaTransportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTransporte categoriaTransporte = _UnityOfWork.CategoriasTransporte.Find(id);
            if (categoriaTransporte == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTransporte);
        }

        // POST: CategoriaTransportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaTransporteId,NomCategoriaTransporte")] CategoriaTransporte categoriaTransporte)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(categoriaTransporte).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaTransporte);
        }

        // GET: CategoriaTransportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaTransporte categoriaTransporte = _UnityOfWork.CategoriasTransporte.Find(id);
            if (categoriaTransporte == null)
            {
                return HttpNotFound();
            }
            return View(categoriaTransporte);
        }

        // POST: CategoriaTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaTransporte categoriaTransporte = _UnityOfWork.CategoriasTransporte.Find(id);
            _UnityOfWork.CategoriasTransporte.Remove(categoriaTransporte);
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
