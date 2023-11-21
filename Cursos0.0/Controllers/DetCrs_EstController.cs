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
    public class DetCrs_EstController : Controller
    {
        private modeloContainer db = new modeloContainer();

        // GET: DetCrs_Est
        public ActionResult Index()
        {
            return View(db.DetCrs_Est.ToList());
        }

        // GET: DetCrs_Est/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetCrs_Est detCrs_Est = db.DetCrs_Est.Find(id);
            if (detCrs_Est == null)
            {
                return HttpNotFound();
            }
            return View(detCrs_Est);
        }

        // GET: DetCrs_Est/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetCrs_Est/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] DetCrs_Est detCrs_Est)
        {
            if (ModelState.IsValid)
            {
                db.DetCrs_Est.Add(detCrs_Est);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detCrs_Est);
        }

        // GET: DetCrs_Est/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetCrs_Est detCrs_Est = db.DetCrs_Est.Find(id);
            if (detCrs_Est == null)
            {
                return HttpNotFound();
            }
            return View(detCrs_Est);
        }

        // POST: DetCrs_Est/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] DetCrs_Est detCrs_Est)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detCrs_Est).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detCrs_Est);
        }

        // GET: DetCrs_Est/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetCrs_Est detCrs_Est = db.DetCrs_Est.Find(id);
            if (detCrs_Est == null)
            {
                return HttpNotFound();
            }
            return View(detCrs_Est);
        }

        // POST: DetCrs_Est/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetCrs_Est detCrs_Est = db.DetCrs_Est.Find(id);
            db.DetCrs_Est.Remove(detCrs_Est);
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
