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
    public class CategoriasHospedajeApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CategoriasHospedajeApiController()
        {

        }

        public CategoriasHospedajeApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/CategoriasHospedajeApi
        //public IQueryable<CategoriaHospedaje> GetCategoriasHospedaje()
        //{
        //    return db.CategoriasHospedaje;
        //}

        // GET api/CategoriasHospedajeApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var CategoriasHospedaje = _UnityOfWork.CategoriasHospedaje.GetAll();

            if (CategoriasHospedaje == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CategoriaHospedaje  = new List<CategoriaHospedaje >();

            foreach (var categoriaHospedaje in CategoriasHospedaje)
                CategoriaHospedaje.Add(Mapper.Map<CategoriaHospedaje, CategoriaHospedaje >(categoriaHospedaje));

            return Ok(CategoriasHospedaje );
        }

        //// GET: api/CategoriasHospedajeApi/5
        //[ResponseType(typeof(CategoriaHospedaje))]
        //public IHttpActionResult GetCategoriaHospedaje(int id)
        //{
        //    CategoriaHospedaje categoriaHospedaje = db.CategoriasHospedaje.Find(id);
        //    if (categoriaHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(categoriaHospedaje);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var categoriaHospedaje = _UnityOfWork.CategoriasHospedaje.Get(id);

            if (categoriaHospedaje == null)
                return NotFound();

            return Ok(Mapper.Map<CategoriaHospedaje, CategoriaHospedaje >(categoriaHospedaje));
        }

        //// PUT: api/CategoriasHospedajeApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategoriaHospedaje(int id, CategoriaHospedaje categoriaHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != categoriaHospedaje.CategoriaHospedajeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(categoriaHospedaje).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoriaHospedajeExists(id))
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
        public IHttpActionResult Update(int id, CategoriaHospedaje  categoriaHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaHospedajeInPersistence = _UnityOfWork.CategoriasHospedaje.Get(id);
            if (categoriaHospedajeInPersistence == null)
                return NotFound();

            Mapper.Map<CategoriaHospedaje , CategoriaHospedaje>(categoriaHospedaje , categoriaHospedajeInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(categoriaHospedaje );
        }

        //// POST: api/CategoriasHospedajeApi
        //[ResponseType(typeof(CategoriaHospedaje))]
        //public IHttpActionResult PostCategoriaHospedaje(CategoriaHospedaje categoriaHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CategoriasHospedaje.Add(categoriaHospedaje);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = categoriaHospedaje.CategoriaHospedajeId }, categoriaHospedaje);
        //}
        [HttpPost]
        public IHttpActionResult Create(CategoriaHospedaje  categoriaHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CategoriaHospedaje = Mapper.Map<CategoriaHospedaje , CategoriaHospedaje>(categoriaHospedaje );

            _UnityOfWork.CategoriasHospedaje.Add(categoriaHospedaje);
            _UnityOfWork.SaveChanges();

            categoriaHospedaje .CategoriaHospedajeId = categoriaHospedaje.CategoriaHospedajeId;

            return Created(new Uri(Request.RequestUri + "/" + categoriaHospedaje.CategoriaHospedajeId), categoriaHospedaje );
        }

        //// DELETE: api/CategoriasHospedajeApi/5
        //[ResponseType(typeof(CategoriaHospedaje))]
        //public IHttpActionResult DeleteCategoriaHospedaje(int id)
        //{
        //    CategoriaHospedaje categoriaHospedaje = db.CategoriasHospedaje.Find(id);
        //    if (categoriaHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CategoriasHospedaje.Remove(categoriaHospedaje);
        //    db.SaveChanges();

        //    return Ok(categoriaHospedaje);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaHospedajeInDataBase = _UnityOfWork.CategoriasHospedaje.Get(id);
            if (categoriaHospedajeInDataBase == null)
                return NotFound();

            _UnityOfWork.CategoriasHospedaje.Delete(categoriaHospedajeInDataBase);
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

        //private bool CategoriaHospedajeExists(int id)
        //{
        //    return db.CategoriasHospedaje.Count(e => e.CategoriaHospedajeId == id) > 0;
        //}
    }
}