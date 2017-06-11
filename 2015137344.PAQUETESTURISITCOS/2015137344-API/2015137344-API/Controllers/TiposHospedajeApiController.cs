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
    public class TiposHospedajeApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public TiposHospedajeApiController()
        {

        }

        public TiposHospedajeApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/TiposHospedajeApi
        //public IQueryable<TipoHospedaje> GetTiposHospedaje()
        //{
        //    return db.TiposHospedaje;
        //}

        // GET api/TiposHospedajeApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var TiposHospedaje = _UnityOfWork.TiposHospedaje.GetAll();

            if (TiposHospedaje == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TipoHospedaje  = new List<TipoHospedaje >();

            foreach (var tipoHospedaje in TiposHospedaje)
                TipoHospedaje .Add(Mapper.Map<TipoHospedaje, TipoHospedaje >(tipoHospedaje));

            return Ok(TiposHospedaje );
        }

        //// GET: api/TiposHospedajeApi/5
        //[ResponseType(typeof(TipoHospedaje))]
        //public IHttpActionResult GetTipoHospedaje(int id)
        //{
        //    TipoHospedaje tipoHospedaje = db.TiposHospedaje.Find(id);
        //    if (tipoHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tipoHospedaje);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipoHospedaje = _UnityOfWork.TiposHospedaje.Get(id);

            if (tipoHospedaje == null)
                return NotFound();

            return Ok(Mapper.Map<TipoHospedaje, TipoHospedaje >(tipoHospedaje));
        }

        //// PUT: api/TiposHospedajeApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTipoHospedaje(int id, TipoHospedaje tipoHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tipoHospedaje.TipoHospedajeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tipoHospedaje).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoHospedajeExists(id))
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
        public IHttpActionResult Update(int id, TipoHospedaje  tipoHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoHospedajeInPersistence = _UnityOfWork.TiposHospedaje.Get(id);
            if (tipoHospedajeInPersistence == null)
                return NotFound();

            Mapper.Map<TipoHospedaje , TipoHospedaje>(tipoHospedaje , tipoHospedajeInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(tipoHospedaje );
        }

        //// POST: api/TiposHospedajeApi
        //[ResponseType(typeof(TipoHospedaje))]
        //public IHttpActionResult PostTipoHospedaje(TipoHospedaje tipoHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TiposHospedaje.Add(tipoHospedaje);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tipoHospedaje.TipoHospedajeId }, tipoHospedaje);
        //}
        [HttpPost]
        public IHttpActionResult Create(TipoHospedaje  tipoHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipoHospedaje = Mapper.Map<TipoHospedaje , TipoHospedaje>(tipoHospedaje );

            _UnityOfWork.TiposHospedaje.Add(tipoHospedaje);
            _UnityOfWork.SaveChanges();

            TipoHospedaje .TipoHospedajeId = tipoHospedaje.TipoHospedajeId;

            return Created(new Uri(Request.RequestUri + "/" + tipoHospedaje.TipoHospedajeId), tipoHospedaje );
        }

        //// DELETE: api/TiposHospedajeApi/5
        //[ResponseType(typeof(TipoHospedaje))]
        //public IHttpActionResult DeleteTipoHospedaje(int id)
        //{
        //    TipoHospedaje tipoHospedaje = db.TiposHospedaje.Find(id);
        //    if (tipoHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TiposHospedaje.Remove(tipoHospedaje);
        //    db.SaveChanges();

        //    return Ok(tipoHospedaje);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoHospedajeInDataBase = _UnityOfWork.TiposHospedaje.Get(id);
            if (tipoHospedajeInDataBase == null)
                return NotFound();

            _UnityOfWork.TiposHospedaje.Delete(tipoHospedajeInDataBase);
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

        //private bool TipoHospedajeExists(int id)
        //{
        //    return db.TiposHospedaje.Count(e => e.TipoHospedajeId == id) > 0;
        //}
    }
}