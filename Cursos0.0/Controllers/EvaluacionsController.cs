using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cursos0._0.Models;

namespace Cursos0._0.Controllers
{
    public class EvaluacionsController : Controller
    {
        private modeloContainer db = new modeloContainer();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluaciones = db.Evaluaciones.Include(e => e.Leccion);
            return View(evaluaciones.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.LeccionId = new SelectList(db.Lecciones, "Id", "Contenido");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,DocumentoEva,LeccionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluaciones.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeccionId = new SelectList(db.Lecciones, "Id", "Contenido", evaluacion.LeccionId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeccionId = new SelectList(db.Lecciones, "Id", "Contenido", evaluacion.LeccionId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,DocumentoEva,LeccionId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeccionId = new SelectList(db.Lecciones, "Id", "Contenido", evaluacion.LeccionId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluaciones.Find(id);
            db.Evaluaciones.Remove(evaluacion);
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
