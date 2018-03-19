using SistemaDemoServicios.Models;
using SistemaDemoServicios.Utils;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SistemaDemoServicios.Controllers.API
{
    [RoutePrefix("api/Agentes")]

    public class AgentesController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: api/Agentes
        [Route("GetAgentes")]
        public async Task<List<AgenteRequest>> GetAgentes()
        {
            return await db.Agente.Select(y=> new AgenteRequest {Id=y.Id,Nombre=y.Nombre }).ToListAsync();
        }
      
        [HttpPost]
        [Route("GetAgente")]
        public async Task<Response> GetAgente([FromBody] Agente agente)
        {
            var resultAgente =await db.Agente.Where(x=>x.Id==agente.Id).Select(y=> new AgenteRequest
                                    {
                                        Id=y.Id,
                                        Nombre=y.Nombre,
                                    }
                                    ).FirstOrDefaultAsync();
            if (resultAgente == null)
            {
                return new Response { IsSuccess=false};
            }

            return new Response { IsSuccess = true, Result = resultAgente };
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