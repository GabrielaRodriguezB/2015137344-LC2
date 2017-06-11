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
    public class HospedajesApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public HospedajesApiController()
        {

        }

        public HospedajesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/HospedajesApi
        //public IQueryable<Hospedaje> GetServicioTuristicoes()
        //{
        //    return db.ServicioTuristicoes;
        //}

        // GET api/HospedajesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Hospedajes = _UnityOfWork.ServiciosTuristicos.GetAll();

            if (Hospedajes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Hospedaje  = new List<ServicioTuristico >();

            foreach (var hospedaje in Hospedajes)
                Hospedaje.Add(Mapper.Map<ServicioTuristico, ServicioTuristico >(hospedaje));

            return Ok(Hospedajes );
        }

        //// GET: api/HospedajesApi/5
        //[ResponseType(typeof(Hospedaje))]
        //public IHttpActionResult GetHospedaje(int id)
        //{
        //    Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
        //    if (hospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(hospedaje);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var hospedaje = _UnityOfWork.ServiciosTuristicos.Get(id);

            if (hospedaje == null)
                return NotFound();

            return Ok(Mapper.Map<ServicioTuristico, ServicioTuristico >(hospedaje));
        }

        //// PUT: api/HospedajesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutHospedaje(int id, Hospedaje hospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != hospedaje.ServicioTuristicoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(hospedaje).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HospedajeExists(id))
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
        public IHttpActionResult Update(int id, ServicioTuristico  hospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hospedajeInPersistence = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (hospedajeInPersistence == null)
                return NotFound();

            Mapper.Map<ServicioTuristico , ServicioTuristico>(hospedaje , hospedajeInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(hospedaje );
        }

        //// POST: api/HospedajesApi
        //[ResponseType(typeof(Hospedaje))]
        //public IHttpActionResult PostHospedaje(Hospedaje hospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ServicioTuristicoes.Add(hospedaje);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = hospedaje.ServicioTuristicoId }, hospedaje);
        //}
        [HttpPost]
        public IHttpActionResult Create(ServicioTuristico  hospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Hospedajes = Mapper.Map<ServicioTuristico , ServicioTuristico>(hospedaje);

            _UnityOfWork.ServiciosTuristicos.Add(hospedaje);
            _UnityOfWork.SaveChanges();

            hospedaje .ServicioTuristicoId = hospedaje.ServicioTuristicoId;

            return Created(new Uri(Request.RequestUri + "/" + hospedaje.ServicioTuristicoId), hospedaje );
        }

        //// DELETE: api/HospedajesApi/5
        //[ResponseType(typeof(Hospedaje))]
        //public IHttpActionResult DeleteHospedaje(int id)
        //{
        //    Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
        //    if (hospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ServicioTuristicoes.Remove(hospedaje);
        //    db.SaveChanges();

        //    return Ok(hospedaje);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hospedajeInDataBase = _UnityOfWork.ServiciosTuristicos.Get(id);
            if (hospedajeInDataBase == null)
                return NotFound();

            _UnityOfWork.ServiciosTuristicos.Delete(hospedajeInDataBase);
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

        //private bool HospedajeExists(int id)
        //{
        //    return db.ServicioTuristicoes.Count(e => e.ServicioTuristicoId == id) > 0;
        //}
    }
}