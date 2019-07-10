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
    public class DEPARTAMENTOSController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: DEPARTAMENTOS
        public ActionResult Index()
        {
            var tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Include(t => t.TBL_ESTADO);
            return View(tBL_DEPARTAMENTO.ToList());
        }

        // GET: DEPARTAMENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // GET: DEPARTAMENTOS/Create
        public ActionResult Create()
        {
            ViewBag.DEP_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            return View();
        }

        // POST: DEPARTAMENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEP_ID,DEP_DESCRIPCION,DEP_DIRRECCION,DEP_ADD,DEP_STATUS")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_DEPARTAMENTO.Add(tBL_DEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEP_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_DEPARTAMENTO.DEP_STATUS);
            return View(tBL_DEPARTAMENTO);
        }

        // GET: DEPARTAMENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEP_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_DEPARTAMENTO.DEP_STATUS);
            return View(tBL_DEPARTAMENTO);
        }

        // POST: DEPARTAMENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEP_ID,DEP_DESCRIPCION,DEP_DIRRECCION,DEP_ADD,DEP_STATUS")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEP_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_DEPARTAMENTO.DEP_STATUS);
            return View(tBL_DEPARTAMENTO);
        }

        // GET: DEPARTAMENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // POST: DEPARTAMENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            db.TBL_DEPARTAMENTO.Remove(tBL_DEPARTAMENTO);
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
