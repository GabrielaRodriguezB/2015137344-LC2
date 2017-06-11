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
    public class TiposComprobanteApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public TiposComprobanteApiController()
        {

        }

        public TiposComprobanteApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/TiposComprobanteApi
        //public IQueryable<TipoComprobante> GetTiposComprobante()
        //{
        //    return db.TiposComprobante;
        //}

        // GET api/TiposComprobanteApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var TiposComprobante = _UnityOfWork.TiposComprobante.GetAll();

            if (TiposComprobante == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TipoComprobante  = new List<TipoComprobante >();

            foreach (var tipoComprobante in TiposComprobante)
                TipoComprobante .Add(Mapper.Map<TipoComprobante, TipoComprobante >(tipoComprobante));

            return Ok(TiposComprobante );
        }

        //// GET: api/TiposComprobanteApi/5
        //[ResponseType(typeof(TipoComprobante))]
        //public IHttpActionResult GetTipoComprobante(int id)
        //{
        //    TipoComprobante tipoComprobante = db.TiposComprobante.Find(id);
        //    if (tipoComprobante == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tipoComprobante);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipoComprobante = _UnityOfWork.TiposComprobante.Get(id);

            if (tipoComprobante == null)
                return NotFound();

            return Ok(Mapper.Map<TipoComprobante, TipoComprobante >(tipoComprobante));
        }

        //// PUT: api/TiposComprobanteApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTipoComprobante(int id, TipoComprobante tipoComprobante)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tipoComprobante.TipoComprobanteId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tipoComprobante).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoComprobanteExists(id))
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
        public IHttpActionResult Update(int id, TipoComprobante  tipoComprobante )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoComprobanteInPersistence = _UnityOfWork.TiposComprobante.Get(id);
            if (tipoComprobanteInPersistence == null)
                return NotFound();

            Mapper.Map<TipoComprobante , TipoComprobante>(tipoComprobante , tipoComprobanteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(tipoComprobante );
        }

        //// POST: api/TiposComprobanteApi
        //[ResponseType(typeof(TipoComprobante))]
        //public IHttpActionResult PostTipoComprobante(TipoComprobante tipoComprobante)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TiposComprobante.Add(tipoComprobante);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tipoComprobante.TipoComprobanteId }, tipoComprobante);
        //}
        [HttpPost]
        public IHttpActionResult Create(TipoComprobante  tipoComprobante )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipoComprobante = Mapper.Map<TipoComprobante , TipoComprobante>(tipoComprobante );

            _UnityOfWork.TiposComprobante.Add(tipoComprobante);
            _UnityOfWork.SaveChanges();

            tipoComprobante .TipoComprobanteId = tipoComprobante.TipoComprobanteId;

            return Created(new Uri(Request.RequestUri + "/" + tipoComprobante.TipoComprobanteId), tipoComprobante );
        }

        //// DELETE: api/TiposComprobanteApi/5
        //[ResponseType(typeof(TipoComprobante))]
        //public IHttpActionResult DeleteTipoComprobante(int id)
        //{
        //    TipoComprobante tipoComprobante = db.TiposComprobante.Find(id);
        //    if (tipoComprobante == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TiposComprobante.Remove(tipoComprobante);
        //    db.SaveChanges();

        //    return Ok(tipoComprobante);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoComprobanteInDataBase = _UnityOfWork.TiposComprobante.Get(id);
            if (tipoComprobanteInDataBase == null)
                return NotFound();

            _UnityOfWork.TiposComprobante.Delete(tipoComprobanteInDataBase);
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

        //private bool TipoComprobanteExists(int id)
        //{
        //    return db.TiposComprobante.Count(e => e.TipoComprobanteId == id) > 0;
        //}
    }
}