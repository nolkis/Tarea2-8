using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyectocf.Model.DAL;
using Proyectocf.Model.Models;

namespace Proyectocf.Controllers
{
    public class InscripcionesController : Controller
    {
        private EstudianteContext db = new EstudianteContext();

        // GET: Inscripciones
        public ActionResult Index()
        {
            var inscripciones = db.Inscripciones.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(inscripciones.ToList());
        }

        // GET: Inscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcione inscripcione = db.Inscripciones.Find(id);
            if (inscripcione == null)
            {
                return HttpNotFound();
            }
            return View(inscripcione);
        }

        // GET: Inscripciones/Create
        public ActionResult Create()
        {
            ViewBag.CursoID = new SelectList(db.Cursos, "CursoID", "Descripcion");
            ViewBag.EstudianteID = new SelectList(db.Estudiantes, "EstudianteID", "Nombres");
            return View();
        }

        // POST: Inscripciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscripcioneID,CursoID,EstudianteID,Semestre")] Inscripcione inscripcione)
        {
            if (ModelState.IsValid)
            {
                db.Inscripciones.Add(inscripcione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoID = new SelectList(db.Cursos, "CursoID", "Descripcion", inscripcione.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiantes, "EstudianteID", "Nombres", inscripcione.EstudianteID);
            return View(inscripcione);
        }

        // GET: Inscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcione inscripcione = db.Inscripciones.Find(id);
            if (inscripcione == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoID = new SelectList(db.Cursos, "CursoID", "Descripcion", inscripcione.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiantes, "EstudianteID", "Nombres", inscripcione.EstudianteID);
            return View(inscripcione);
        }

        // POST: Inscripciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscripcioneID,CursoID,EstudianteID,Semestre")] Inscripcione inscripcione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoID = new SelectList(db.Cursos, "CursoID", "Descripcion", inscripcione.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiantes, "EstudianteID", "Nombres", inscripcione.EstudianteID);
            return View(inscripcione);
        }

        // GET: Inscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcione inscripcione = db.Inscripciones.Find(id);
            if (inscripcione == null)
            {
                return HttpNotFound();
            }
            return View(inscripcione);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcione inscripcione = db.Inscripciones.Find(id);
            db.Inscripciones.Remove(inscripcione);
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
