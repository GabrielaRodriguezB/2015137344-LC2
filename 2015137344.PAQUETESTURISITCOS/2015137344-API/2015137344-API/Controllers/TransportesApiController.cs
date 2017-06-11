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
    public class TransportesApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public TransportesApiController()
        {
                
        }

        public TransportesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/TransportesApi
        //public IQueryable<Transporte> GetServicioTuristicoes()
        //{
        //    return db.ServicioTuristicoes;
        //}

        // GET api/TransportesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Transportes = _UnityOfWork.ServiciosTuristicos.GetAll();

            if (Transportes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Transporte  = new List<ServicioTuristico >();

            foreach (var transporte in Transportes)
                Transporte .Add(Mapper.Map<ServicioTuristico, ServicioTuristico >(transporte));

            return Ok(Transportes );
        }

        //// GET: api/TransportesApi/5
        //[ResponseType(typeof(Transporte))]
        //public IHttpActionResult GetTransporte(int id)
        //{
        //    Transporte transporte = db.ServicioTuristicoes.Find(id);
        //    if (transporte == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(transporte);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var transporte = _UnityOfWork.ServiciosTuristicos.Get(id);

            if (transporte == null)
                return NotFound();

            return Ok(Mapper.Map<ServicioTuristico, ServicioTuristico >(transporte));
        }

        //// PUT: api/TransportesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTransporte(int id, Transporte transporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != transporte.ServicioTuristicoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(transporte).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TransporteExists(id))
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
        public IHttpActionResult Update(int id, ServicioTuristico  transporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transporteInPersistence = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (transporteInPersistence == null)
                return NotFound();

            Mapper.Map<ServicioTuristico , ServicioTuristico>(transporte , transporteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(transporte );
        }

        //// POST: api/TransportesApi
        //[ResponseType(typeof(Transporte))]
        //public IHttpActionResult PostTransporte(Transporte transporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ServicioTuristicoes.Add(transporte);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = transporte.ServicioTuristicoId }, transporte);
        //}
        [HttpPost]
        public IHttpActionResult Create(ServicioTuristico  transporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Transporte = Mapper.Map<ServicioTuristico , ServicioTuristico>(transporte );

            _UnityOfWork.ServiciosTuristicos.Add(transporte);
            _UnityOfWork.SaveChanges();

            transporte .ServicioTuristicoId = transporte.ServicioTuristicoId;

            return Created(new Uri(Request.RequestUri + "/" + transporte.ServicioTuristicoId), transporte );
        }

        //// DELETE: api/TransportesApi/5
        //[ResponseType(typeof(Transporte))]
        //public IHttpActionResult DeleteTransporte(int id)
        //{
        //    Transporte transporte = db.ServicioTuristicoes.Find(id);
        //    if (transporte == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ServicioTuristicoes.Remove(transporte);
        //    db.SaveChanges();

        //    return Ok(transporte);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transporteInDataBase = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (transporteInDataBase == null)
                return NotFound();

            _UnityOfWork.ServiciosTuristicos.Delete(transporteInDataBase);
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

        //private bool TransporteExists(int id)
        //{
        //    return db.ServicioTuristicoes.Count(e => e.ServicioTuristicoId == id) > 0;
        //}
    }
}