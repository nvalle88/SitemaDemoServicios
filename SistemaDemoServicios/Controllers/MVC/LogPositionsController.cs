using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaDemoServicios;

namespace SistemaDemoServicios.Controllers.MVC
{
    public class LogPositionsController : Controller
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: LogPositions
        public ActionResult Index()
        {
            var logPosition = db.LogPosition.Include(l => l.Agente);
            return View(logPosition.ToList());
        }

        // GET: LogPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogPosition logPosition = db.LogPosition.Find(id);
            if (logPosition == null)
            {
                return HttpNotFound();
            }
            return View(logPosition);
        }

        // GET: LogPositions/Create
        public ActionResult Create()
        {
            ViewBag.idAgente = new SelectList(db.Agente, "Id", "Nombre");
            return View();
        }

        // POST: LogPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idAgente,Lat,Lon,Fecha")] LogPosition logPosition)
        {
            if (ModelState.IsValid)
            {
                db.LogPosition.Add(logPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAgente = new SelectList(db.Agente, "Id", "Nombre", logPosition.idAgente);
            return View(logPosition);
        }

        // GET: LogPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogPosition logPosition = db.LogPosition.Find(id);
            if (logPosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAgente = new SelectList(db.Agente, "Id", "Nombre", logPosition.idAgente);
            return View(logPosition);
        }

        // POST: LogPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idAgente,Lat,Lon,Fecha")] LogPosition logPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAgente = new SelectList(db.Agente, "Id", "Nombre", logPosition.idAgente);
            return View(logPosition);
        }

        // GET: LogPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogPosition logPosition = db.LogPosition.Find(id);
            if (logPosition == null)
            {
                return HttpNotFound();
            }
            return View(logPosition);
        }

        // POST: LogPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogPosition logPosition = db.LogPosition.Find(id);
            db.LogPosition.Remove(logPosition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
