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
    public class ClientesApiController : ApiController
    {
        //private PaquetesTuristicosDbContext db = new PaquetesTuristicosDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ClientesApiController()
        {

        }

        public ClientesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        //// GET: api/ClientesApi
        //public IQueryable<Cliente> GetPersonas()
        //{
        //    return db.Personas;
        //}

        // GET api/ClientesApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Clientes = _UnityOfWork.Personas.GetAll();

            if (Clientes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var Cliente  = new List<Persona >();

            foreach (var cliente in Clientes)
                Cliente .Add(Mapper.Map<Persona, Persona >(cliente));

            return Ok(Clientes );
        }

        //// GET: api/ClientesApi/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult GetCliente(int id)
        //{
        //    Cliente cliente = db.Personas.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cliente);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cliente = _UnityOfWork.Personas.Get(id);

            if (cliente == null)
                return NotFound();

            return Ok(Mapper.Map<Persona, Persona >(cliente));
        }

        //// PUT: api/ClientesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCliente(int id, Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cliente.PersonaId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
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
        public IHttpActionResult Update(int id, Persona  cliente )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clienteInPersistence = _UnityOfWork.Personas.Get(id);
            if (clienteInPersistence == null)
                return NotFound();

            Mapper.Map<Persona , Persona>(cliente , clienteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(cliente );
        }

        //// POST: api/ClientesApi
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult PostCliente(Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Personas.Add(cliente);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = cliente.PersonaId }, cliente);
        //}
        [HttpPost]
        public IHttpActionResult Create(Persona  cliente )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Cliente = Mapper.Map<Persona , Persona>(cliente );

            _UnityOfWork.Personas.Add(cliente);
            _UnityOfWork.SaveChanges();

            cliente .PersonaId = cliente.PersonaId;

            return Created(new Uri(Request.RequestUri + "/" + cliente.PersonaId), cliente );
        }

        //// DELETE: api/ClientesApi/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult DeleteCliente(int id)
        //{
        //    Cliente cliente = db.Personas.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Personas.Remove(cliente);
        //    db.SaveChanges();

        //    return Ok(cliente);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clienteInDataBase = _UnityOfWork.Personas.Get(id);
            if (clienteInDataBase == null)
                return NotFound();

            _UnityOfWork.Personas.Delete(clienteInDataBase);
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

        //private bool ClienteExists(int id)
        //{
        //    return db.Personas.Count(e => e.PersonaId == id) > 0;
        //}
    }
}