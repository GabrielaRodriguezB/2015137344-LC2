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
    public class TiposTransporteApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public TiposTransporteApiController()
        {

        }

        public TiposTransporteApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/TiposTransporteApi
        //public IQueryable<TipoTransporte> GetTiposTransporte()
        //{
        //    return db.TiposTransporte;
        //}

        // GET api/TiposTransporteApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var TiposTransporte = _UnityOfWork.TiposTransporte.GetAll();

            if (TiposTransporte == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TipoTransporte  = new List<TipoTransporte >();

            foreach (var tipoTransporte in TiposTransporte)
                TipoTransporte .Add(Mapper.Map<TipoTransporte, TipoTransporte >(tipoTransporte));

            return Ok(TiposTransporte );
        }

        //// GET: api/TiposTransporteApi/5
        //[ResponseType(typeof(TipoTransporte))]
        //public IHttpActionResult GetTipoTransporte(int id)
        //{
        //    TipoTransporte tipoTransporte = db.TiposTransporte.Find(id);
        //    if (tipoTransporte == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tipoTransporte);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipoTransporte = _UnityOfWork.TiposTransporte.Get(id);

            if (tipoTransporte == null)
                return NotFound();

            return Ok(Mapper.Map<TipoTransporte, TipoTransporte >(tipoTransporte));
        }

        //// PUT: api/TiposTransporteApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTipoTransporte(int id, TipoTransporte tipoTransporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tipoTransporte.TipoTransporteId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tipoTransporte).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoTransporteExists(id))
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
        public IHttpActionResult Update(int id, TipoTransporte  tipoTransporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoTransporteInPersistence = _UnityOfWork.TiposTransporte.Get(id);
            if (tipoTransporteInPersistence == null)
                return NotFound();

            Mapper.Map<TipoTransporte , TipoTransporte>(tipoTransporte , tipoTransporteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(tipoTransporte );
        }

        //// POST: api/TiposTransporteApi
        //[ResponseType(typeof(TipoTransporte))]
        //public IHttpActionResult PostTipoTransporte(TipoTransporte tipoTransporte)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TiposTransporte.Add(tipoTransporte);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tipoTransporte.TipoTransporteId }, tipoTransporte);
        //}
        [HttpPost]
        public IHttpActionResult Create(TipoTransporte  tipoTransporte )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipoTransporte = Mapper.Map<TipoTransporte , TipoTransporte>(tipoTransporte );

            _UnityOfWork.TiposTransporte.Add(tipoTransporte);
            _UnityOfWork.SaveChanges();

            tipoTransporte .TipoTransporteId = tipoTransporte.TipoTransporteId;

            return Created(new Uri(Request.RequestUri + "/" + tipoTransporte.TipoTransporteId), tipoTransporte );
        }

        //// DELETE: api/TiposTransporteApi/5
        //[ResponseType(typeof(TipoTransporte))]
        //public IHttpActionResult DeleteTipoTransporte(int id)
        //{
        //    TipoTransporte tipoTransporte = db.TiposTransporte.Find(id);
        //    if (tipoTransporte == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TiposTransporte.Remove(tipoTransporte);
        //    db.SaveChanges();

        //    return Ok(tipoTransporte);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoTransporteInDataBase = _UnityOfWork.TiposTransporte.Get(id);
            if (tipoTransporteInDataBase == null)
                return NotFound();

            _UnityOfWork.TiposTransporte.Delete(tipoTransporteInDataBase);
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

        //private bool TipoTransporteExists(int id)
        //{
        //    return db.TiposTransporte.Count(e => e.TipoTransporteId == id) > 0;
        //}
    }
}