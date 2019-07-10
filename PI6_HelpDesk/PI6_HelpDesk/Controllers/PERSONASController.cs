using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI6_HelpDesk.Models;

namespace PI6_HelpDesk.Controllers
{
    [Authorize]
    public class PERSONASController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: PERSONAS
        public ActionResult Index()
        {
            var tBL_PERSONA = db.TBL_PERSONA.Include(t => t.TBL_DEPARTAMENTO).Include(t => t.TBL_ESTADO);
            return View(tBL_PERSONA.ToList());
        }

        // GET: PERSONAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONA tBL_PERSONA = db.TBL_PERSONA.Find(id);
            if (tBL_PERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PERSONA);
        }

        // GET: PERSONAS/Create
        public ActionResult Create()
        {
            ViewBag.DEP_ID = new SelectList(db.TBL_DEPARTAMENTO, "DEP_ID", "DEP_DESCRIPCION");
            ViewBag.PER_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            return View();
        }

        // POST: PERSONAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PER_ID,DEP_ID,PER_TIPOIDENTIFICACION,PER_IDENTIFICACION,PER_APELLIDOS,PER_NOMBRES,PER_DIRECCION,PER_TELEFONO,PER_EMAIL,PER_ADD,PER_STATUS")] TBL_PERSONA tBL_PERSONA)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PERSONA.Add(tBL_PERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEP_ID = new SelectList(db.TBL_DEPARTAMENTO, "DEP_ID", "DEP_DESCRIPCION", tBL_PERSONA.DEP_ID);
            ViewBag.PER_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PERSONA.PER_STATUS);
            return View(tBL_PERSONA);
        }

        // GET: PERSONAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONA tBL_PERSONA = db.TBL_PERSONA.Find(id);
            if (tBL_PERSONA == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEP_ID = new SelectList(db.TBL_DEPARTAMENTO, "DEP_ID", "DEP_DESCRIPCION", tBL_PERSONA.DEP_ID);
            ViewBag.PER_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PERSONA.PER_STATUS);
            return View(tBL_PERSONA);
        }

        // POST: PERSONAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PER_ID,DEP_ID,PER_TIPOIDENTIFICACION,PER_IDENTIFICACION,PER_APELLIDOS,PER_NOMBRES,PER_DIRECCION,PER_TELEFONO,PER_EMAIL,PER_ADD,PER_STATUS")] TBL_PERSONA tBL_PERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEP_ID = new SelectList(db.TBL_DEPARTAMENTO, "DEP_ID", "DEP_DESCRIPCION", tBL_PERSONA.DEP_ID);
            ViewBag.PER_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PERSONA.PER_STATUS);
            return View(tBL_PERSONA);
        }

        // GET: PERSONAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONA tBL_PERSONA = db.TBL_PERSONA.Find(id);
            if (tBL_PERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PERSONA);
        }

        // POST: PERSONAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PERSONA tBL_PERSONA = db.TBL_PERSONA.Find(id);
            db.TBL_PERSONA.Remove(tBL_PERSONA);
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
