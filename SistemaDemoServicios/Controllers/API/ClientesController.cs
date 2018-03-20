using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaDemoServicios;
using SistemaDemoServicios.Models;
using SistemaDemoServicios.Utils;
using SistemaDemoServicios.Utils.GeoUtils;

namespace SistemaDemoServicios.Controllers.API
{
    [RoutePrefix("api/Clientes")]

    public class ClientesController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();
        // GET: api/Clientes
        [HttpGet]
        public async Task <List<ClienteRequest>> GetCliente()
        {
            var clientes = await db.Cliente.Select(y=> new ClienteRequest
            {
                Id = y.Id,
                Direccion = y.Direccion,
                Lat = y.Lat,
                Lon = y.Lon,
                Nombre = y.Nombre,
                Ruc = y.Ruc,
                PersonaContacto = y.PersonaContacto,
                Telefono = y.Telefono
            }
            
            ).ToListAsync();
            return clientes;
        }
       // [Route("Getcliente")]
       // [HttpGet]
       // public async Task<List<ClienteRequest>> GetallCliente()
       // {
       //    var clientes= await db.Cliente.ToListAsync();
       //     foreach (Plaza plaza in PlazaDB)
       //     {
       //}
        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cliente.Add(cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }

        [ResponseType(typeof(Cliente))]
        [HttpPost]
        [Route("GetNearClients")]
        public async Task<List<Cliente>> GetClientForPosition(Position posicion)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var clientes = await db.Cliente.ToListAsync();
            List<Cliente> Clientes = new List<Cliente>();

            foreach (var cliente in clientes)
            {
                var cposition = new Position
                {
                latitude=cliente.Lat,
                longitude=cliente.Lon               
                };
                if (GeoUtils.EstaCercaDeMi(posicion, cposition,0.1))
                {
                    Clientes.Add(cliente);
                }
            }
            return Clientes;
        }



        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Cliente.Count(e => e.Id == id) > 0;
        }
    }
}