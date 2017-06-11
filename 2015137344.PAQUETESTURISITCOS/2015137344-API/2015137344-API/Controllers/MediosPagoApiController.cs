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
    public class MediosPagoApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public MediosPagoApiController()
        {

        }

        public MediosPagoApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/MediosPagoApi
        //public IQueryable<MedioPago> GetMediosPago()
        //{
        //    return db.MediosPago;
        //}

        // GET api/MediosPagoApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var MediosPago = _UnityOfWork.MediosPago.GetAll();

            if (MediosPago == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var MedioPago  = new List<MedioPago >();

            foreach (var medioPago in MediosPago)
                MedioPago .Add(Mapper.Map<MedioPago, MedioPago >(medioPago));

            return Ok(MediosPago );
        }

        //// GET: api/MediosPagoApi/5
        //[ResponseType(typeof(MedioPago))]
        //public IHttpActionResult GetMedioPago(int id)
        //{
        //    MedioPago medioPago = db.MediosPago.Find(id);
        //    if (medioPago == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(medioPago);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var medioPago = _UnityOfWork.MediosPago.Get(id);

            if (medioPago == null)
                return NotFound();

            return Ok(Mapper.Map<MedioPago, MedioPago >(medioPago));
        }

        //// PUT: api/MediosPagoApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMedioPago(int id, MedioPago medioPago)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != medioPago.MedioPagoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(medioPago).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MedioPagoExists(id))
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
        public IHttpActionResult Update(int id, MedioPago  medioPago )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medioPagoInPersistence = _UnityOfWork.MediosPago.Get(id);
            if (medioPagoInPersistence == null)
                return NotFound();

            Mapper.Map<MedioPago , MedioPago>(medioPago , medioPagoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(medioPago );
        }

        //// POST: api/MediosPagoApi
        //[ResponseType(typeof(MedioPago))]
        //public IHttpActionResult PostMedioPago(MedioPago medioPago)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.MediosPago.Add(medioPago);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = medioPago.MedioPagoId }, medioPago);
        //}
        [HttpPost]
        public IHttpActionResult Create(MedioPago  medioPago )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var MedioPago = Mapper.Map<MedioPago , MedioPago>(medioPago );

            _UnityOfWork.MediosPago.Add(medioPago);
            _UnityOfWork.SaveChanges();

            medioPago .MedioPagoId = medioPago.MedioPagoId;

            return Created(new Uri(Request.RequestUri + "/" + medioPago.MedioPagoId), medioPago );
        }

        //// DELETE: api/MediosPagoApi/5
        //[ResponseType(typeof(MedioPago))]
        //public IHttpActionResult DeleteMedioPago(int id)
        //{
        //    MedioPago medioPago = db.MediosPago.Find(id);
        //    if (medioPago == null)
        //    {
        //        return NotFound();
        //    }

        //    db.MediosPago.Remove(medioPago);
        //    db.SaveChanges();

        //    return Ok(medioPago);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medioPagoInDataBase = _UnityOfWork.MediosPago.Get(id);
            if (medioPagoInDataBase == null)
                return NotFound();

            _UnityOfWork.MediosPago.Delete(medioPagoInDataBase);
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

        //private bool MedioPagoExists(int id)
        //{
        //    return db.MediosPago.Count(e => e.MedioPagoId == id) > 0;
        //}
    }
}