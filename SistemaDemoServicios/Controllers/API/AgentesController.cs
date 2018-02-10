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
using SistemaDemoServicios;

namespace SistemaDemoServicios.Controllers.API
{
    public class AgentesController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: api/Agentes
        public IQueryable<Agente> GetAgente()
        {
            return db.Agente;
        }
        public void hola()
        { }

        // GET: api/Agentes/5
        [ResponseType(typeof(Agente))]
        public IHttpActionResult GetAgente(int id)
        {
            Agente agente = db.Agente.Find(id);
            if (agente == null)
            {
                return NotFound();
            }

            return Ok(agente);
        }

        // PUT: api/Agentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgente(int id, Agente agente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agente.Id)
            {
                return BadRequest();
            }

            db.Entry(agente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Agentes
        [ResponseType(typeof(Agente))]
        public IHttpActionResult PostAgente(Agente agente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agente.Add(agente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agente.Id }, agente);
        }

        // DELETE: api/Agentes/5
        [ResponseType(typeof(Agente))]
        public IHttpActionResult DeleteAgente(int id)
        {
            Agente agente = db.Agente.Find(id);
            if (agente == null)
            {
                return NotFound();
            }

            db.Agente.Remove(agente);
            db.SaveChanges();

            return Ok(agente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenteExists(int id)
        {
            return db.Agente.Count(e => e.Id == id) > 0;
        }
    }
}