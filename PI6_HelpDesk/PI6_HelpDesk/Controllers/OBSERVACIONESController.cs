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
    public class OBSERVACIONESController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: OBSERVACIONES
        public ActionResult Index()
        {
            var tBL_OBSERVACION = db.TBL_OBSERVACION.Include(t => t.TBL_ESTADO).Include(t => t.TBL_INCIDENTE).Include(t => t.TBL_PERSONA);
            return View(tBL_OBSERVACION.ToList());
        }

        // GET: OBSERVACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_OBSERVACION tBL_OBSERVACION = db.TBL_OBSERVACION.Find(id);
            if (tBL_OBSERVACION == null)
            {
                return HttpNotFound();
            }
            return View(tBL_OBSERVACION);
        }

        // GET: OBSERVACIONES/Create
        public ActionResult Create()
        {
            ViewBag.OBS_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            ViewBag.INC_ID = new SelectList(db.TBL_INCIDENTE, "INC_ID", "INC_NUMTICKET");
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION");
            return View();
        }

        // POST: OBSERVACIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OBS_ID,PER_ID,INC_ID,OBS_FECHA,OBS_COMENTARIO,OBS_STATUS,OBS_ADD")] TBL_OBSERVACION tBL_OBSERVACION)
        {
            if (ModelState.IsValid)
            {
                db.TBL_OBSERVACION.Add(tBL_OBSERVACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OBS_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_OBSERVACION.OBS_STATUS);
            ViewBag.INC_ID = new SelectList(db.TBL_INCIDENTE, "INC_ID", "INC_NUMTICKET", tBL_OBSERVACION.INC_ID);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_OBSERVACION.PER_ID);
            return View(tBL_OBSERVACION);
        }

        // GET: OBSERVACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_OBSERVACION tBL_OBSERVACION = db.TBL_OBSERVACION.Find(id);
            if (tBL_OBSERVACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.OBS_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_OBSERVACION.OBS_STATUS);
            ViewBag.INC_ID = new SelectList(db.TBL_INCIDENTE, "INC_ID", "INC_NUMTICKET", tBL_OBSERVACION.INC_ID);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_OBSERVACION.PER_ID);
            return View(tBL_OBSERVACION);
        }

        // POST: OBSERVACIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OBS_ID,PER_ID,INC_ID,OBS_FECHA,OBS_COMENTARIO,OBS_STATUS,OBS_ADD")] TBL_OBSERVACION tBL_OBSERVACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_OBSERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OBS_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_OBSERVACION.OBS_STATUS);
            ViewBag.INC_ID = new SelectList(db.TBL_INCIDENTE, "INC_ID", "INC_NUMTICKET", tBL_OBSERVACION.INC_ID);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_OBSERVACION.PER_ID);
            return View(tBL_OBSERVACION);
        }

        // GET: OBSERVACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_OBSERVACION tBL_OBSERVACION = db.TBL_OBSERVACION.Find(id);
            if (tBL_OBSERVACION == null)
            {
                return HttpNotFound();
            }
            return View(tBL_OBSERVACION);
        }

        // POST: OBSERVACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_OBSERVACION tBL_OBSERVACION = db.TBL_OBSERVACION.Find(id);
            db.TBL_OBSERVACION.Remove(tBL_OBSERVACION);
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
