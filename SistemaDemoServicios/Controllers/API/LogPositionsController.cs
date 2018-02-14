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
    [RoutePrefix("api/LogPositions")]

    public class LogPositionsController : ApiController
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: api/LogPositions
        public IQueryable<LogPosition> GetLogPosition()
        {
            return db.LogPosition;
        }

        // GET: api/LogPositions/5
        [ResponseType(typeof(LogPosition))]
        public IHttpActionResult GetLogPosition(int id)
        {
            LogPosition logPosition = db.LogPosition.Find(id);
            if (logPosition == null)
            {
                return NotFound();
            }

            return Ok(logPosition);
        }

        // PUT: api/LogPositions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogPosition(int id, LogPosition logPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logPosition.id)
            {
                return BadRequest();
            }

            db.Entry(logPosition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogPositionExists(id))
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

        // POST: api/LogPositions
        [ResponseType(typeof(LogPosition))]
        public IHttpActionResult PostLogPosition(LogPosition logPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogPosition.Add(logPosition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = logPosition.id }, logPosition);
        }

        // DELETE: api/LogPositions/5
        [ResponseType(typeof(LogPosition))]
        public IHttpActionResult DeleteLogPosition(int id)
        {
            LogPosition logPosition = db.LogPosition.Find(id);
            if (logPosition == null)
            {
                return NotFound();
            }

            db.LogPosition.Remove(logPosition);
            db.SaveChanges();

            return Ok(logPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogPositionExists(int id)
        {
            return db.LogPosition.Count(e => e.id == id) > 0;
        }
    }
}