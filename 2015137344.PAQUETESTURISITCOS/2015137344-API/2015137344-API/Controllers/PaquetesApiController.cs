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
    public class PaquetesApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public PaquetesApiController()
        {

        }

        public PaquetesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/PaquetesApi
        //public IQueryable<Paquete> GetPaquetes()
        //{
        //    return db.Paquetes;
        //}

        // GET api/PaquetesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Paquetes = _UnityOfWork.Paquetes.GetAll();

            if (Paquetes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Paquete  = new List<Paquete >();

            foreach (var paquete in Paquetes)
                Paquete .Add(Mapper.Map<Paquete, Paquete >(paquete));

            return Ok(Paquetes );
        }

        //// GET: api/PaquetesApi/5
        //[ResponseType(typeof(Paquete))]
        //public IHttpActionResult GetPaquete(int id)
        //{
        //    Paquete paquete = db.Paquetes.Find(id);
        //    if (paquete == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(paquete);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var paquete = _UnityOfWork.Paquetes.Get(id);

            if (paquete == null)
                return NotFound();

            return Ok(Mapper.Map<Paquete, Paquete >(paquete));
        }

        //// PUT: api/PaquetesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPaquete(int id, Paquete paquete)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != paquete.PaqueteId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(paquete).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaqueteExists(id))
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
        public IHttpActionResult Update(int id, Paquete  paquete )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var paqueteInPersistence = _UnityOfWork.Paquetes.Get(id);
            if (paqueteInPersistence == null)
                return NotFound();

            Mapper.Map<Paquete , Paquete>(paquete , paqueteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(paquete );
        }

        //// POST: api/PaquetesApi
        //[ResponseType(typeof(Paquete))]
        //public IHttpActionResult PostPaquete(Paquete paquete)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Paquetes.Add(paquete);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = paquete.PaqueteId }, paquete);
        //}
        [HttpPost]
        public IHttpActionResult Create(Paquete  paquete )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Paquete = Mapper.Map<Paquete , Paquete>(paquete );

            _UnityOfWork.Paquetes.Add(paquete);
            _UnityOfWork.SaveChanges();

            paquete .PaqueteId = paquete.PaqueteId;

            return Created(new Uri(Request.RequestUri + "/" + paquete.PaqueteId), paquete );
        }

        //// DELETE: api/PaquetesApi/5
        //[ResponseType(typeof(Paquete))]
        //public IHttpActionResult DeletePaquete(int id)
        //{
        //    Paquete paquete = db.Paquetes.Find(id);
        //    if (paquete == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Paquetes.Remove(paquete);
        //    db.SaveChanges();

        //    return Ok(paquete);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var paqueteInDataBase = _UnityOfWork.Paquetes.Get(id);
            if (paqueteInDataBase == null)
                return NotFound();

            _UnityOfWork.Paquetes.Delete(paqueteInDataBase);
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

        //private bool PaqueteExists(int id)
        //{
        //    return db.Paquetes.Count(e => e.PaqueteId == id) > 0;
        //}
    }
}