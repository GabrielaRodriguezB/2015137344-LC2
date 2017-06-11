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
    public class EmpleadosApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public EmpleadosApiController()
        {

        }

        public EmpleadosApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/EmpleadosApi
        //public IQueryable<Empleado> GetPersonas()
        //{
        //    return db.Personas;
        //}

        // GET api/EmpleadosApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Empleados = _UnityOfWork.Personas.GetAll();

            if (Empleados == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Empleado  = new List<Persona >();

            foreach (var empleado in Empleados)
                Empleado .Add(Mapper.Map<Persona, Persona >(empleado));

            return Ok(Empleados );
        }

        //// GET: api/EmpleadosApi/5
        //[ResponseType(typeof(Empleado))]
        //public IHttpActionResult GetEmpleado(int id)
        //{
        //    Empleado empleado = db.Personas.Find(id);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(empleado);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var empleado = _UnityOfWork.Personas.Get(id);

            if (empleado == null)
                return NotFound();

            return Ok(Mapper.Map<Persona, Persona >(empleado));
        }

        //// PUT: api/EmpleadosApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != empleado.PersonaId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(empleado).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmpleadoExists(id))
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
        public IHttpActionResult Update(int id, Persona  empleado )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var empleadoInPersistence = _UnityOfWork.Personas.Get(id);
            if (empleadoInPersistence == null)
                return NotFound();

            Mapper.Map<Persona , Persona>(empleado , empleadoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(empleado );
        }

        //// POST: api/EmpleadosApi
        //[ResponseType(typeof(Empleado))]
        //public IHttpActionResult PostEmpleado(Empleado empleado)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Personas.Add(empleado);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = empleado.PersonaId }, empleado);
        //}
        [HttpPost]
        public IHttpActionResult Create(Persona  empleado )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Empleado = Mapper.Map<Persona , Persona>(empleado );

            _UnityOfWork.Personas.Add(empleado);
            _UnityOfWork.SaveChanges();

            empleado .PersonaId = empleado.PersonaId;

            return Created(new Uri(Request.RequestUri + "/" + empleado.PersonaId), empleado );
        }

        //// DELETE: api/EmpleadosApi/5
        //[ResponseType(typeof(Empleado))]
        //public IHttpActionResult DeleteEmpleado(int id)
        //{
        //    Empleado empleado = db.Personas.Find(id);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Personas.Remove(empleado);
        //    db.SaveChanges();

        //    return Ok(empleado);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var empleadoInDataBase = _UnityOfWork.Personas.Get(id);
            if (empleadoInDataBase == null)
                return NotFound();

            _UnityOfWork.Personas.Delete(empleadoInDataBase);
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

        //private bool EmpleadoExists(int id)
        //{
        //    return db.Personas.Count(e => e.PersonaId == id) > 0;
        //}
    }
}