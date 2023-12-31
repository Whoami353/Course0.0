﻿using System;
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
    public class ResultadoEvasController : Controller
    {
        private modeloContainer db = new modeloContainer();

        // GET: ResultadoEvas
        public ActionResult Index()
        {
            return View(db.ResultadosEva.ToList());
        }

        // GET: ResultadoEvas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoEva resultadoEva = db.ResultadosEva.Find(id);
            if (resultadoEva == null)
            {
                return HttpNotFound();
            }
            return View(resultadoEva);
        }

        // GET: ResultadoEvas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultadoEvas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comentario,Valoracion,EstudianteId")] ResultadoEva resultadoEva)
        {
            if (ModelState.IsValid)
            {
                db.ResultadosEva.Add(resultadoEva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultadoEva);
        }

        // GET: ResultadoEvas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoEva resultadoEva = db.ResultadosEva.Find(id);
            if (resultadoEva == null)
            {
                return HttpNotFound();
            }
            return View(resultadoEva);
        }

        // POST: ResultadoEvas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comentario,Valoracion,EstudianteId")] ResultadoEva resultadoEva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultadoEva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultadoEva);
        }

        // GET: ResultadoEvas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoEva resultadoEva = db.ResultadosEva.Find(id);
            if (resultadoEva == null)
            {
                return HttpNotFound();
            }
            return View(resultadoEva);
        }

        // POST: ResultadoEvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultadoEva resultadoEva = db.ResultadosEva.Find(id);
            db.ResultadosEva.Remove(resultadoEva);
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
