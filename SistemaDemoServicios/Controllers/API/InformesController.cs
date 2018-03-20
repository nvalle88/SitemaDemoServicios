using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaDemoServicios;
using SistemaDemoServicios.ModeloDatos;
using SistemaDemoServicios.Utils;

namespace SistemaDemoServicios.Controllers.API
{
    public class InformesController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();


        //POST: api/Informe/Subir
        [HttpPost]
        [Route("Subir")]
        public Response SubirFirma(FirmaRequest firmaRequest)
        {
            db.Configuration.ProxyCreationEnabled = false;


            var stream = new MemoryStream(firmaRequest.Array);

            var file = string.Format("{0}.jpg", firmaRequest.Id);
            var folder = "~/Content/Firmas";
            var fullPath = string.Format("{0}/{1}", folder, file);

         

            var response = FileHelper.UploadFoto(stream, folder, file);

            if (!response)
            {
                BadRequest("Imagen de la Firma no se pudo subir al servidor...");
            }

            return new Response
            {
                Result = true,
                Message= fullPath,

            };

        }



        // GET: api/Informes
        public IQueryable<Informe> GetInforme()
        {
            return db.Informe;
        }

        // GET: api/Informes/5
        [ResponseType(typeof(Informe))]
        public IHttpActionResult GetInforme(int id)
        {
            Informe informe = db.Informe.Find(id);
            if (informe == null)
            {
                return NotFound();
            }

            return Ok(informe);
        }

        // PUT: api/Informes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInforme(int id, Informe informe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informe.Id)
            {
                return BadRequest();
            }

            db.Entry(informe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeExists(id))
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

        // POST: api/Informes
        [ResponseType(typeof(Informe))]
        public IHttpActionResult PostInforme(Informe informe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Informe.Add(informe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = informe.Id }, informe);
        }

        // DELETE: api/Informes/5
        [ResponseType(typeof(Informe))]
        public IHttpActionResult DeleteInforme(int id)
        {
            Informe informe = db.Informe.Find(id);
            if (informe == null)
            {
                return NotFound();
            }

            db.Informe.Remove(informe);
            db.SaveChanges();

            return Ok(informe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformeExists(int id)
        {
            return db.Informe.Count(e => e.Id == id) > 0;
        }
    }
}