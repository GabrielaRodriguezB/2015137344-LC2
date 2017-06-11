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
    public class VentasPaquetesApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public VentasPaquetesApiController()
        {

        }

        public VentasPaquetesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/VentasPaquetesApi
        //public IQueryable<VentaPaquete> GetVentasPaquetes()
        //{
        //    return db.VentasPaquetes;
        //}

        // GET api/VentasPaquetesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var VentasPaquetes = _UnityOfWork.VentasPaquetes.GetAll();

            if (VentasPaquetes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var VentaPaquetes  = new List<VentaPaquete >();

            foreach (var ventaPaquete in VentasPaquetes)
                VentaPaquetes .Add(Mapper.Map<VentaPaquete, VentaPaquete >(ventaPaquete));

            return Ok(VentasPaquetes );
        }

        //// GET: api/VentasPaquetesApi/5
        //[ResponseType(typeof(VentaPaquete))]
        //public IHttpActionResult GetVentaPaquete(int id)
        //{
        //    VentaPaquete ventaPaquete = db.VentasPaquetes.Find(id);
        //    if (ventaPaquete == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ventaPaquete);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var ventaPaquete = _UnityOfWork.VentasPaquetes.Get(id);

            if (ventaPaquete == null)
                return NotFound();

            return Ok(Mapper.Map<VentaPaquete, VentaPaquete >(ventaPaquete));
        }

        //// PUT: api/VentasPaquetesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutVentaPaquete(int id, VentaPaquete ventaPaquete)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ventaPaquete.VentaPaqueteId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(ventaPaquete).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VentaPaqueteExists(id))
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
        public IHttpActionResult Update(int id, VentaPaquete  ventaPaquete )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ventaPaqueteInPersistence = _UnityOfWork.VentasPaquetes.Get(id);
            if (ventaPaqueteInPersistence == null)
                return NotFound();

            Mapper.Map<VentaPaquete , VentaPaquete>(ventaPaquete , ventaPaqueteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ventaPaquete );
        }

        //// POST: api/VentasPaquetesApi
        //[ResponseType(typeof(VentaPaquete))]
        //public IHttpActionResult PostVentaPaquete(VentaPaquete ventaPaquete)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.VentasPaquetes.Add(ventaPaquete);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = ventaPaquete.VentaPaqueteId }, ventaPaquete);
        //}
        [HttpPost]
        public IHttpActionResult Create(VentaPaquete  ventaPaquete )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var VentaPaquete = Mapper.Map<VentaPaquete , VentaPaquete>(ventaPaquete );

            _UnityOfWork.VentasPaquetes.Add(ventaPaquete);
            _UnityOfWork.SaveChanges();

            ventaPaquete .VentaPaqueteId = ventaPaquete.VentaPaqueteId;

            return Created(new Uri(Request.RequestUri + "/" + ventaPaquete.VentaPaqueteId), ventaPaquete );
        }

        //// DELETE: api/VentasPaquetesApi/5
        //[ResponseType(typeof(VentaPaquete))]
        //public IHttpActionResult DeleteVentaPaquete(int id)
        //{
        //    VentaPaquete ventaPaquete = db.VentasPaquetes.Find(id);
        //    if (ventaPaquete == null)
        //    {
        //        return NotFound();
        //    }

        //    db.VentasPaquetes.Remove(ventaPaquete);
        //    db.SaveChanges();

        //    return Ok(ventaPaquete);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ventaPaqueteInDataBase = _UnityOfWork.VentasPaquetes.Get(id);
            if (ventaPaqueteInDataBase == null)
                return NotFound();

            _UnityOfWork.VentasPaquetes.Delete(ventaPaqueteInDataBase);
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

        //private bool VentaPaqueteExists(int id)
        //{
        //    return db.VentasPaquetes.Count(e => e.VentaPaqueteId == id) > 0;
        //}
    }
}