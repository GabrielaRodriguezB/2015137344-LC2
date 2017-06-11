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
    public class CalificacionesHospedajeApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CalificacionesHospedajeApiController()
        {

        }

        public CalificacionesHospedajeApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/CalificacionesHospedajeApi
        //public IQueryable<CalificacionHospedaje> GetCalificacionesHospedaje()
        //{
        //    return db.CalificacionesHospedaje;
        //}

        // GET api/CalificacionesHospedajeApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var CalificacionesHospedaje = _UnityOfWork.CalificacionesHospedaje.GetAll();

            if (CalificacionesHospedaje == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CalificacionHospedaje  = new List<CalificacionHospedaje >();

            foreach (var calificacionHospedaje in CalificacionesHospedaje)
                CalificacionHospedaje.Add(Mapper.Map<CalificacionHospedaje, CalificacionHospedaje >(calificacionHospedaje));

            return Ok(CalificacionesHospedaje );
        }

        //// GET: api/CalificacionesHospedajeApi/5
        //[ResponseType(typeof(CalificacionHospedaje))]
        //public IHttpActionResult GetCalificacionHospedaje(int id)
        //{
        //    CalificacionHospedaje calificacionHospedaje = db.CalificacionesHospedaje.Find(id);
        //    if (calificacionHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(calificacionHospedaje);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var calificacionHospedaje = _UnityOfWork.CalificacionesHospedaje.Get(id);

            if (calificacionHospedaje == null)
                return NotFound();

            return Ok(Mapper.Map<CalificacionHospedaje, CalificacionHospedaje >(calificacionHospedaje));
        }

        //// PUT: api/CalificacionesHospedajeApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCalificacionHospedaje(int id, CalificacionHospedaje calificacionHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != calificacionHospedaje.CalificacionHospedajeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(calificacionHospedaje).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CalificacionHospedajeExists(id))
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
        public IHttpActionResult Update(int id, CalificacionHospedaje  calificacionHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var calificacionHospedajeInPersistence = _UnityOfWork.CalificacionesHospedaje.Get(id);
            if (calificacionHospedajeInPersistence == null)
                return NotFound();

            Mapper.Map<CalificacionHospedaje , CalificacionHospedaje>(calificacionHospedaje , calificacionHospedajeInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(calificacionHospedaje );
        }

        //// POST: api/CalificacionesHospedajeApi
        //[ResponseType(typeof(CalificacionHospedaje))]
        //public IHttpActionResult PostCalificacionHospedaje(CalificacionHospedaje calificacionHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CalificacionesHospedaje.Add(calificacionHospedaje);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = calificacionHospedaje.CalificacionHospedajeId }, calificacionHospedaje);
        //}
        [HttpPost]
        public IHttpActionResult Create(CalificacionHospedaje  calificacionHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var CalificacionHospedaje = Mapper.Map<CalificacionHospedaje , CalificacionHospedaje>(calificacionHospedaje );

            _UnityOfWork.CalificacionesHospedaje.Add(calificacionHospedaje);
            _UnityOfWork.SaveChanges();

            calificacionHospedaje .CalificacionHospedajeId = calificacionHospedaje.CalificacionHospedajeId;

            return Created(new Uri(Request.RequestUri + "/" + calificacionHospedaje.CalificacionHospedajeId), calificacionHospedaje );
        }

        //// DELETE: api/CalificacionesHospedajeApi/5
        //[ResponseType(typeof(CalificacionHospedaje))]
        //public IHttpActionResult DeleteCalificacionHospedaje(int id)
        //{
        //    CalificacionHospedaje calificacionHospedaje = db.CalificacionesHospedaje.Find(id);
        //    if (calificacionHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CalificacionesHospedaje.Remove(calificacionHospedaje);
        //    db.SaveChanges();

        //    return Ok(calificacionHospedaje);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var calificacionHospedajeInDataBase = _UnityOfWork.CalificacionesHospedaje.Get(id);
            if (calificacionHospedajeInDataBase == null)
                return NotFound();

            _UnityOfWork.CalificacionesHospedaje.Delete(calificacionHospedajeInDataBase);
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

        //private bool CalificacionHospedajeExists(int id)
        //{
        //    return db.CalificacionesHospedaje.Count(e => e.CalificacionHospedajeId == id) > 0;
        //}
    }
}