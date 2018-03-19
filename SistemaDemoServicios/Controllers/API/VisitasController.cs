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
using SistemaDemoServicios.Utils;
using SistemaDemoServicios.Models;

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
        public async Task<List<PuntosRequest>> GetVisitasDiarias([FromBody] VisitaDiaria visitaDiaria)
        {
            DateTime fechaActual = visitaDiaria.Fecha;
            var listaVisitas = await db.Visita
                             .Where(x => x.IdAgente == visitaDiaria.IdAgente
                                && x.Fecha.Day==fechaActual.Day 
                                && x.Fecha.Month==fechaActual.Month   
                                && x.Fecha.Year==fechaActual.Year)
                             .Include(x=>x.Cliente)
                             .OrderBy(x => x.Fecha)
                             .Select(y=> new PuntosRequest
                                        {
                                 lat = (Double)y.Cliente.Lat,
                                 lng = (Double)y.Cliente.Lon,
                                 Fecha = y.Fecha,
                                 NombreUsuario = y.Cliente.Nombre,
                                 Direccion = y.Cliente.Direccion,
                                 PersonaContacto = y.Cliente.PersonaContacto,
                                 Ruc = y.Cliente.Ruc,
                                 Telefono = y.Cliente.Telefono,
                                 Tipo = y.Tipo == 1 ? "Venta" : "Visita",
                                 Valor = y.Valor,

                             }
                             )
                             .ToListAsync();
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


        // POST: api/Visitas
        [ResponseType(typeof(Visita))]
        [HttpPost]
        [Route("PostCheckin")]
        public Response PostCheckin(Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return new Response
                {
                    IsSuccess=false,
                    Result= BadRequest(ModelState),
                    Message="Error"

                };
            }

            db.Visita.Add(visita);
            db.SaveChanges();



             CreatedAtRoute("DefaultApi", new { id = visita.Id }, visita);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
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