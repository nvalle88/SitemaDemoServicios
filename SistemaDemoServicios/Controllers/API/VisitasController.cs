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
using System.Threading.Tasks;

namespace SistemaDemoServicios.Controllers.API
{

    [RoutePrefix("api/Visitas")]
    public class VisitasController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: api/Visitas
        public IQueryable<Visita> GetVisita()
        {
            return db.Visita;
        }

        [HttpPost]
        [Route("GetVisitasDiarias")]
        public async Task<List<Visita>> GetVisitasDiarias([FromBody] Agente agente)
        {
            DateTime fechaActual = DateTime.Now;
            var listaVisitas = await db.Visita
                             .Where(x => x.IdAgente == agente.Id
                                   && (x.Fecha.Value.Day == fechaActual.Day
                                       && x.Fecha.Value.Month == fechaActual.Month
                                       && x.Fecha.Value.Year == fechaActual.Year)).OrderBy(x => x.Fecha).ToListAsync();
            return listaVisitas;
        }

        // GET: api/Visitas/5
        [ResponseType(typeof(Visita))]
        public IHttpActionResult GetVisita(int id)
        {
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return NotFound();
            }

            return Ok(visita);
        }

        // PUT: api/Visitas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisita(int id, Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visita.Id)
            {
                return BadRequest();
            }

            db.Entry(visita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visitas
        [ResponseType(typeof(Visita))]
        public IHttpActionResult PostVisita(Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visita.Add(visita);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visita.Id }, visita);
        }

        // DELETE: api/Visitas/5
        [ResponseType(typeof(Visita))]
        public IHttpActionResult DeleteVisita(int id)
        {
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return NotFound();
            }

            db.Visita.Remove(visita);
            db.SaveChanges();

            return Ok(visita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitaExists(int id)
        {
            return db.Visita.Count(e => e.Id == id) > 0;
        }
    }
}