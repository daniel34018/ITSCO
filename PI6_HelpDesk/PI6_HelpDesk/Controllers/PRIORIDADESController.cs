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
    public class PRIORIDADESController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: PRIORIDADES
        public ActionResult Index()
        {
            var tBL_PRIORIDAD = db.TBL_PRIORIDAD.Include(t => t.TBL_ESTADO);
            return View(tBL_PRIORIDAD.ToList());
        }

        // GET: PRIORIDADES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRIORIDAD tBL_PRIORIDAD = db.TBL_PRIORIDAD.Find(id);
            if (tBL_PRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRIORIDAD);
        }

        // GET: PRIORIDADES/Create
        public ActionResult Create()
        {
            ViewBag.PRI_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            return View();
        }

        // POST: PRIORIDADES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRI_ID,PRI_NOMBRE,PRI_STATUS,PRI_ADD")] TBL_PRIORIDAD tBL_PRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PRIORIDAD.Add(tBL_PRIORIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRI_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PRIORIDAD.PRI_STATUS);
            return View(tBL_PRIORIDAD);
        }

        // GET: PRIORIDADES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRIORIDAD tBL_PRIORIDAD = db.TBL_PRIORIDAD.Find(id);
            if (tBL_PRIORIDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRI_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PRIORIDAD.PRI_STATUS);
            return View(tBL_PRIORIDAD);
        }

        // POST: PRIORIDADES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRI_ID,PRI_NOMBRE,PRI_STATUS,PRI_ADD")] TBL_PRIORIDAD tBL_PRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PRIORIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRI_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_PRIORIDAD.PRI_STATUS);
            return View(tBL_PRIORIDAD);
        }

        // GET: PRIORIDADES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRIORIDAD tBL_PRIORIDAD = db.TBL_PRIORIDAD.Find(id);
            if (tBL_PRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRIORIDAD);
        }

        // POST: PRIORIDADES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PRIORIDAD tBL_PRIORIDAD = db.TBL_PRIORIDAD.Find(id);
            db.TBL_PRIORIDAD.Remove(tBL_PRIORIDAD);
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
