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
    public class ServiciosHospedajeApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ServiciosHospedajeApiController()
        {

        }

        public ServiciosHospedajeApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/ServiciosHospedajeApi
        //public IQueryable<ServicioHospedaje> GetServiciosHospedaje()
        //{
        //    return db.ServiciosHospedaje;
        //}

        // GET api/ServiciosHospedajeApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var ServiciosHospedaje = _UnityOfWork.ServiciosHospedaje.GetAll();

            if (ServiciosHospedaje == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ServicioHospedaje  = new List<ServicioHospedaje >();

            foreach (var servicioHospedaje in ServiciosHospedaje)
                ServicioHospedaje .Add(Mapper.Map<ServicioHospedaje, ServicioHospedaje >(servicioHospedaje));

            return Ok(ServiciosHospedaje );
        }

        //// GET: api/ServiciosHospedajeApi/5
        //[ResponseType(typeof(ServicioHospedaje))]
        //public IHttpActionResult GetServicioHospedaje(int id)
        //{
        //    ServicioHospedaje servicioHospedaje = db.ServiciosHospedaje.Find(id);
        //    if (servicioHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(servicioHospedaje);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var servicioHospedaje = _UnityOfWork.ServiciosHospedaje.Get(id);

            if (servicioHospedaje == null)
                return NotFound();

            return Ok(Mapper.Map<ServicioHospedaje, ServicioHospedaje >(servicioHospedaje));
        }

        //// PUT: api/ServiciosHospedajeApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutServicioHospedaje(int id, ServicioHospedaje servicioHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != servicioHospedaje.ServicioHospedajeId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(servicioHospedaje).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ServicioHospedajeExists(id))
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
        public IHttpActionResult Update(int id, ServicioHospedaje  servicioHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var servicioHospedajeInPersistence = _UnityOfWork.ServiciosHospedaje.Get(id);
            if (servicioHospedajeInPersistence == null)
                return NotFound();

            Mapper.Map<ServicioHospedaje , ServicioHospedaje>(servicioHospedaje , servicioHospedajeInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(servicioHospedaje );
        }

        //// POST: api/ServiciosHospedajeApi
        //[ResponseType(typeof(ServicioHospedaje))]
        //public IHttpActionResult PostServicioHospedaje(ServicioHospedaje servicioHospedaje)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ServiciosHospedaje.Add(servicioHospedaje);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = servicioHospedaje.ServicioHospedajeId }, servicioHospedaje);
        //}
        [HttpPost]
        public IHttpActionResult Create(ServicioHospedaje  servicioHospedaje )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ServicioHospedaje = Mapper.Map<ServicioHospedaje , ServicioHospedaje>(servicioHospedaje );

            _UnityOfWork.ServiciosHospedaje.Add(servicioHospedaje);
            _UnityOfWork.SaveChanges();

            servicioHospedaje .ServicioHospedajeId = servicioHospedaje.ServicioHospedajeId;

            return Created(new Uri(Request.RequestUri + "/" + servicioHospedaje.ServicioHospedajeId), servicioHospedaje );
        }

        //// DELETE: api/ServiciosHospedajeApi/5
        //[ResponseType(typeof(ServicioHospedaje))]
        //public IHttpActionResult DeleteServicioHospedaje(int id)
        //{
        //    ServicioHospedaje servicioHospedaje = db.ServiciosHospedaje.Find(id);
        //    if (servicioHospedaje == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ServiciosHospedaje.Remove(servicioHospedaje);
        //    db.SaveChanges();

        //    return Ok(servicioHospedaje);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var servicioHospedajeInDataBase = _UnityOfWork.ServiciosHospedaje.Get(id);
            if (servicioHospedajeInDataBase == null)
                return NotFound();

            _UnityOfWork.ServiciosHospedaje.Delete(servicioHospedajeInDataBase);
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

        //private bool ServicioHospedajeExists(int id)
        //{
        //    return db.ServiciosHospedaje.Count(e => e.ServicioHospedajeId == id) > 0;
        //}
    }
}