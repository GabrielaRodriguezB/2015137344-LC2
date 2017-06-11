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
    public class AlimentacionesApiController : ApiController
    {
       // private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public AlimentacionesApiController()
        {

        }

        public AlimentacionesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/AlimentacionesApi
        //public IQueryable<Alimentacion> GetServicioTuristicoes()
        //{
        //    return db.ServicioTuristicoes;
        //}

        // GET api/AlimentacionesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Alimentaciones = _UnityOfWork.ServiciosTuristicos.GetAll();

            if (Alimentaciones == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Alimentacion  = new List<ServicioTuristico >();

            foreach (var alimentacion in Alimentaciones)
                Alimentacion.Add(Mapper.Map<ServicioTuristico, ServicioTuristico >(alimentacion));

            return Ok(Alimentaciones );
        }

        //// GET: api/AlimentacionesApi/5
        //[ResponseType(typeof(Alimentacion))]
        //public IHttpActionResult GetAlimentacion(int id)
        //{
        //    Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
        //    if (alimentacion == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(alimentacion);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var alimentacion = _UnityOfWork.ServiciosTuristicos.Get(id);

            if (alimentacion == null)
                return NotFound();

            return Ok(Mapper.Map<ServicioTuristico, ServicioTuristico >(alimentacion));
        }

        //// PUT: api/AlimentacionesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAlimentacion(int id, Alimentacion alimentacion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != alimentacion.ServicioTuristicoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(alimentacion).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AlimentacionExists(id))
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
        public IHttpActionResult Update(int id, ServicioTuristico  alimentacion )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alimentacionInPersistence = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (alimentacionInPersistence == null)
                return NotFound();

            Mapper.Map<ServicioTuristico , ServicioTuristico>(alimentacion , alimentacionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(alimentacion );
        }

        //// POST: api/AlimentacionesApi
        //[ResponseType(typeof(Alimentacion))]
        //public IHttpActionResult PostAlimentacion(Alimentacion alimentacion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ServicioTuristicoes.Add(alimentacion);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = alimentacion.ServicioTuristicoId }, alimentacion);
        //}
        [HttpPost]
        public IHttpActionResult Create(ServicioTuristico  alimentacion )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Alimentacion = Mapper.Map<ServicioTuristico , ServicioTuristico>(alimentacion );

            _UnityOfWork.ServiciosTuristicos.Add(alimentacion);
            _UnityOfWork.SaveChanges();

            alimentacion .ServicioTuristicoId = alimentacion.ServicioTuristicoId;

            return Created(new Uri(Request.RequestUri + "/" + alimentacion.ServicioTuristicoId), alimentacion );
        }

        //// DELETE: api/AlimentacionesApi/5
        //[ResponseType(typeof(Alimentacion))]
        //public IHttpActionResult DeleteAlimentacion(int id)
        //{
        //    Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
        //    if (alimentacion == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ServicioTuristicoes.Remove(alimentacion);
        //    db.SaveChanges();

        //    return Ok(alimentacion);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alimentacionInDataBase = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (alimentacionInDataBase == null)
                return NotFound();

            _UnityOfWork.ServiciosTuristicos.Delete(alimentacionInDataBase);
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

        //private bool AlimentacionExists(int id)
        //{
        //    return db.ServicioTuristicoes.Count(e => e.ServicioTuristicoId == id) > 0;
        //}
    }
}