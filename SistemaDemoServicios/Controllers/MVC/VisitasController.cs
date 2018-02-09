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
    public class VisitasController : Controller
    {
        private SistemaEjemploEntities db = new SistemaEjemploEntities();

        // GET: Visitas
        public ActionResult Index()
        {
            var visita = db.Visita.Include(v => v.Agente).Include(v => v.Cliente);
            return View(visita.ToList());
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.IdAgente = new SelectList(db.Agente, "Id", "Nombre");
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre");
            return View();
        }

        // POST: Visitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCliente,IdAgente,Fecha,Observacion")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgente = new SelectList(db.Agente, "Id", "Nombre", visita.IdAgente);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", visita.IdCliente);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgente = new SelectList(db.Agente, "Id", "Nombre", visita.IdAgente);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", visita.IdCliente);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCliente,IdAgente,Fecha,Observacion")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgente = new SelectList(db.Agente, "Id", "Nombre", visita.IdAgente);
            ViewBag.IdCliente = new SelectList(db.Cliente, "Id", "Nombre", visita.IdCliente);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visita.Find(id);
            db.Visita.Remove(visita);
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
