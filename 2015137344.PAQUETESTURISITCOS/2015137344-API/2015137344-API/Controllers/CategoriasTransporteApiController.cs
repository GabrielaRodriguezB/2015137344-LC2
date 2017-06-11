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
using _2015137344_ENT.Entities ;
using _2015137344_ENT.IRepositories;
using _2015137344_PER;
using AutoMapper;

namespace _2015137344_API.Controllers
{
    public class CategoriasTransporteApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CategoriasTransporteApiController()
        {

        }

        public CategoriasTransporteApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/CategoriasTransporteApi
        //public IQueryable<CategoriaTransporte> GetCategoriasTransporte()
        //{
        //    return db.CategoriasTransporte;
        //}

        // GET api/CategoriasTransporteApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var CategoriasTransporte = _UnityOfWork.CategoriasTransporte.GetAll();

            if (CategoriasTransporte == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CategoriaTransporte  = new List<CategoriaTransporte >();

            foreach (var categoriaTransporte in CategoriasTransporte)
                CategoriaTransporte .Add(Mapper.Map<CategoriaTransporte, CategoriaTransporte >(categoriaTransporte));

            return Ok(CategoriasTransporte );
        }

        //// GET: api/CategoriasTransporteApi/5
        //[ResponseType(typeof(CategoriaTransporte))]
        //public IHttpActionResult GetCategoriaTransporte(int id)
        //{
        //    CategoriaTransporte categoriaTransporte = db.CategoriasTransporte.Find(id);
        //    if (categoriaTransporte == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(categoriaTransporte);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var categoriaTransporte = _UnityOfWork.CategoriasTransporte.Get(id);

            if (categoriaTransporte == null)
                return NotFound();

            return Ok(Mapper.Map<CategoriaTransporte, CategoriaTransporte >(categoriaTransporte));
        }

        //// PUT: api/CategoriasTransporteApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategoriaTransporte(int id, CategoriaTransporte categoriaTransporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != categoriaTransporte.CategoriaTransporteId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(categoriaTransporte).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoriaTransporteExists(id))
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
        public IHttpActionResult Update(int id, CategoriaTransporte  categoriaTransporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaTransporteInPersistence = _UnityOfWork.CategoriasTransporte.Get(id);
            if (categoriaTransporteInPersistence == null)
                return NotFound();

            Mapper.Map<CategoriaTransporte , CategoriaTransporte>(categoriaTransporte , categoriaTransporteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(categoriaTransporte );
        }

        //// POST: api/CategoriasTransporteApi
        //[ResponseType(typeof(CategoriaTransporte))]
        //public IHttpActionResult PostCategoriaTransporte(CategoriaTransporte categoriaTransporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CategoriasTransporte.Add(categoriaTransporte);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = categoriaTransporte.CategoriaTransporteId }, categoriaTransporte);
        //}
        [HttpPost]
        public IHttpActionResult Create(CategoriaTransporte  categoriaTransporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CategoriaTransporte = Mapper.Map<CategoriaTransporte , CategoriaTransporte>(categoriaTransporte );

            _UnityOfWork.CategoriasTransporte.Add(categoriaTransporte);
            _UnityOfWork.SaveChanges();

            categoriaTransporte .CategoriaTransporteId = categoriaTransporte.CategoriaTransporteId;

            return Created(new Uri(Request.RequestUri + "/" + categoriaTransporte.CategoriaTransporteId), categoriaTransporte );
        }

        //// DELETE: api/CategoriasTransporteApi/5
        //[ResponseType(typeof(CategoriaTransporte))]
        //public IHttpActionResult DeleteCategoriaTransporte(int id)
        //{
        //    CategoriaTransporte categoriaTransporte = db.CategoriasTransporte.Find(id);
        //    if (categoriaTransporte == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CategoriasTransporte.Remove(categoriaTransporte);
        //    db.SaveChanges();

        //    return Ok(categoriaTransporte);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaTransporteInDataBase = _UnityOfWork.CategoriasTransporte.Get(id);
            if (categoriaTransporteInDataBase == null)
                return NotFound();

            _UnityOfWork.CategoriasTransporte.Delete(categoriaTransporteInDataBase);
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

        //private bool CategoriaTransporteExists(int id)
        //{
        //    return db.CategoriasTransporte.Count(e => e.CategoriaTransporteId == id) > 0;
        //}
    }
}