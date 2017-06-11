using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2015137344_ENT.Entities;
using _2015137344_ENT.IRepositories;
using _2015137344_PER;
using AutoMapper;

namespace _2015137344_API.Controllers
{
    public class CategoriasAlimentacionApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CategoriasAlimentacionApiController()
        {

        }

        public CategoriasAlimentacionApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/CategoriasAlimentacionApi
        //public IQueryable<CategoriaAlimentacion> GetCategoriasAlimentacion()
        //{
        //    return db.CategoriasAlimentacion;
        //}

        // GET api/CategoriasAlimentacionApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var CategoriasAlimentacion = _UnityOfWork.CategoriasAlimentacion.GetAll();

            if (CategoriasAlimentacion == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CategoriaAlimentacion  = new List<CategoriaAlimentacion>();

            foreach (var categoriaAlimentacion in CategoriasAlimentacion)
                CategoriaAlimentacion.Add(Mapper.Map<CategoriaAlimentacion, CategoriaAlimentacion>(categoriaAlimentacion));

            return Ok(CategoriasAlimentacion );
        }

        //// GET: api/CategoriasAlimentacionApi/5
        //[ResponseType(typeof(CategoriaAlimentacion))]
        //public IHttpActionResult GetCategoriaAlimentacion(int id)
        //{
        //    CategoriaAlimentacion categoriaAlimentacion = db.CategoriasAlimentacion.Find(id);
        //    if (categoriaAlimentacion == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(categoriaAlimentacion);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var categoriaAlimentacion = _UnityOfWork.CategoriasAlimentacion.Get(id);

            if (categoriaAlimentacion == null)
                return NotFound();

            return Ok(Mapper.Map<CategoriaAlimentacion, CategoriaAlimentacion >(categoriaAlimentacion));
        }

        //// PUT: api/CategoriasAlimentacionApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategoriaAlimentacion(int id, CategoriaAlimentacion categoriaAlimentacion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != categoriaAlimentacion.CategoriaAlimentacionId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(categoriaAlimentacion).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoriaAlimentacionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        [HttpPut]
        public IHttpActionResult Update(int id, CategoriaAlimentacion  categoriaAlimentacion )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaAlimentacionInPersistence = _UnityOfWork.CategoriasAlimentacion.Get(id);
            if (categoriaAlimentacionInPersistence == null)
                return NotFound();

            Mapper.Map<CategoriaAlimentacion , CategoriaAlimentacion>(categoriaAlimentacion , categoriaAlimentacionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(categoriaAlimentacion );
        }

        //// POST: api/CategoriasAlimentacionApi
        //[ResponseType(typeof(CategoriaAlimentacion))]
        //public IHttpActionResult PostCategoriaAlimentacion(CategoriaAlimentacion categoriaAlimentacion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CategoriasAlimentacion.Add(categoriaAlimentacion);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = categoriaAlimentacion.CategoriaAlimentacionId }, categoriaAlimentacion);
        //}
        [HttpPost]
        public IHttpActionResult Create(CategoriaAlimentacion  categoriaAlimentacion )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CategoriaAlimentacion = Mapper.Map<CategoriaAlimentacion , CategoriaAlimentacion>(categoriaAlimentacion );

            _UnityOfWork.CategoriasAlimentacion.Add(categoriaAlimentacion);
            _UnityOfWork.SaveChanges();

            categoriaAlimentacion .CategoriaAlimentacionId = categoriaAlimentacion.CategoriaAlimentacionId;

            return Created(new Uri(Request.RequestUri + "/" + categoriaAlimentacion.CategoriaAlimentacionId), categoriaAlimentacion );
        }

        //// DELETE: api/CategoriasAlimentacionApi/5
        //[ResponseType(typeof(CategoriaAlimentacion))]
        //public IHttpActionResult DeleteCategoriaAlimentacion(int id)
        //{
        //    CategoriaAlimentacion categoriaAlimentacion = db.CategoriasAlimentacion.Find(id);
        //    if (categoriaAlimentacion == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CategoriasAlimentacion.Remove(categoriaAlimentacion);
        //    db.SaveChanges();

        //    return Ok(categoriaAlimentacion);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaAlimentacionInDataBase = _UnityOfWork.CategoriasAlimentacion.Get(id);
            if (categoriaAlimentacionInDataBase == null)
                return NotFound();

            _UnityOfWork.CategoriasAlimentacion.Delete(categoriaAlimentacionInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool CategoriaAlimentacionExists(int id)
        //{
        //    return db.CategoriasAlimentacion.Count(e => e.CategoriaAlimentacionId == id) > 0;
        //}
    }
}