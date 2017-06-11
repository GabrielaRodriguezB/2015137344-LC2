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
    public class ComprobantesPagoApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ComprobantesPagoApiController()
        {

        }

        public ComprobantesPagoApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/ComprobantesPagoApi
        //public IQueryable<ComprobantePago> GetComprobantesPago()
        //{
        //    return db.ComprobantesPago;
        //}

        // GET api/ComprobantesPagoApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var ComprobantesPago = _UnityOfWork.ComprobantesPago.GetAll();

            if (ComprobantesPago == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ComprobantePago  = new List<ComprobantePago >();

            foreach (var comprobantePago in ComprobantesPago)
                ComprobantePago .Add(Mapper.Map<ComprobantePago, ComprobantePago >(comprobantePago));

            return Ok(ComprobantesPago );
        }

        //// GET: api/ComprobantesPagoApi/5
        //[ResponseType(typeof(ComprobantePago))]
        //public IHttpActionResult GetComprobantePago(int id)
        //{
        //    ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
        //    if (comprobantePago == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(comprobantePago);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var comprobantePago = _UnityOfWork.ComprobantesPago.Get(id);

            if (comprobantePago == null)
                return NotFound();

            return Ok(Mapper.Map<ComprobantePago, ComprobantePago >(comprobantePago));
        }

        //// PUT: api/ComprobantesPagoApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutComprobantePago(int id, ComprobantePago comprobantePago)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != comprobantePago.ComprobantePagoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(comprobantePago).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComprobantePagoExists(id))
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
        public IHttpActionResult Update(int id, ComprobantePago  comprobantePago )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comprobantePagoInPersistence = _UnityOfWork.ComprobantesPago.Get(id);
            if (comprobantePagoInPersistence == null)
                return NotFound();

            Mapper.Map<ComprobantePago , ComprobantePago>(comprobantePago , comprobantePagoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(comprobantePago );
        }

        //// POST: api/ComprobantesPagoApi
        //[ResponseType(typeof(ComprobantePago))]
        //public IHttpActionResult PostComprobantePago(ComprobantePago comprobantePago)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ComprobantesPago.Add(comprobantePago);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = comprobantePago.ComprobantePagoId }, comprobantePago);
        //}
        [HttpPost]
        public IHttpActionResult Create(ComprobantePago  comprobantePago )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ComprobantePago = Mapper.Map<ComprobantePago , ComprobantePago>(comprobantePago );

            _UnityOfWork.ComprobantesPago.Add(comprobantePago);
            _UnityOfWork.SaveChanges();

            comprobantePago .ComprobantePagoId = comprobantePago.ComprobantePagoId;

            return Created(new Uri(Request.RequestUri + "/" + comprobantePago.ComprobantePagoId), comprobantePago );
        }

        //// DELETE: api/ComprobantesPagoApi/5
        //[ResponseType(typeof(ComprobantePago))]
        //public IHttpActionResult DeleteComprobantePago(int id)
        //{
        //    ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
        //    if (comprobantePago == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ComprobantesPago.Remove(comprobantePago);
        //    db.SaveChanges();

        //    return Ok(comprobantePago);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comprobantePagoInDataBase = _UnityOfWork.ComprobantesPago.Get(id);
            if (comprobantePagoInDataBase == null)
                return NotFound();

            _UnityOfWork.ComprobantesPago.Delete(comprobantePagoInDataBase);
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

        //private bool ComprobantePagoExists(int id)
        //{
        //    return db.ComprobantesPago.Count(e => e.ComprobantePagoId == id) > 0;
        //}
    }
}