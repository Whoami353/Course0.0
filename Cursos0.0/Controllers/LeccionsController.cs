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
    public class LeccionsController : Controller
    {
        private modeloContainer db = new modeloContainer();

        // GET: Leccions
        public ActionResult Index()
        {
            var lecciones = db.Lecciones.Include(l => l.Curso);
            return View(lecciones.ToList());
        }

        // GET: Leccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            return View(leccion);
        }

        // GET: Leccions/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre");
            return View();
        }

        // POST: Leccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Contenido,Descripcion,VideoLec,DocumentoLec,ImagLec,CursoId")] Leccion leccion)
        {
            if (ModelState.IsValid)
            {
                db.Lecciones.Add(leccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", leccion.CursoId);
            return View(leccion);
        }

        // GET: Leccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", leccion.CursoId);
            return View(leccion);
        }

        // POST: Leccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Contenido,Descripcion,VideoLec,DocumentoLec,ImagLec,CursoId")] Leccion leccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nombre", leccion.CursoId);
            return View(leccion);
        }

        // GET: Leccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leccion leccion = db.Lecciones.Find(id);
            if (leccion == null)
            {
                return HttpNotFound();
            }
            return View(leccion);
        }

        // POST: Leccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leccion leccion = db.Lecciones.Find(id);
            db.Lecciones.Remove(leccion);
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
