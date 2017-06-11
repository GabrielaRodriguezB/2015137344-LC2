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
    public class CategoriaAlimentacionsController : Controller
    {
        public CategoriaAlimentacionsController()
        {

        }
        private PaquetesTuristicosDbContext _UnityOfWork = new PaquetesTuristicosDbContext();

        // GET: CategoriaAlimentacions
        public ActionResult Index()
        {
            return View(_UnityOfWork.CategoriasAlimentacion.ToList());
        }

        // GET: CategoriaAlimentacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaAlimentacion categoriaAlimentacion = _UnityOfWork.CategoriasAlimentacion.Find(id);
            if (categoriaAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriaAlimentacion);
        }

        // GET: CategoriaAlimentacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaAlimentacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaAlimentacionId,NomCategoriaAlimentacion")] CategoriaAlimentacion categoriaAlimentacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CategoriasAlimentacion.Add(categoriaAlimentacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaAlimentacion);
        }

        // GET: CategoriaAlimentacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaAlimentacion categoriaAlimentacion = _UnityOfWork.CategoriasAlimentacion.Find(id);
            if (categoriaAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriaAlimentacion);
        }

        // POST: CategoriaAlimentacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaAlimentacionId,NomCategoriaAlimentacion")] CategoriaAlimentacion categoriaAlimentacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Entry(categoriaAlimentacion).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaAlimentacion);
        }

        // GET: CategoriaAlimentacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaAlimentacion categoriaAlimentacion = _UnityOfWork.CategoriasAlimentacion.Find(id);
            if (categoriaAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriaAlimentacion);
        }

        // POST: CategoriaAlimentacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaAlimentacion categoriaAlimentacion = _UnityOfWork.CategoriasAlimentacion.Find(id);
            _UnityOfWork.CategoriasAlimentacion.Remove(categoriaAlimentacion);
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
