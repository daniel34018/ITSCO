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
    public class INCIDENTESController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: INCIDENTES
        public ActionResult Index()
        {
            var tBL_INCIDENTE = db.TBL_INCIDENTE.Include(t => t.TBL_ESTADO).Include(t => t.TBL_PRIORIDAD).Include(t => t.TBL_USUARIO);
            return View(tBL_INCIDENTE.ToList());
        }

        // GET: INCIDENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_INCIDENTE tBL_INCIDENTE = db.TBL_INCIDENTE.Find(id);
            if (tBL_INCIDENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_INCIDENTE);
        }

        // GET: INCIDENTES/Create
        public ActionResult Create()
        {
            ViewBag.INC_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            ViewBag.INC_PRIORIDAD = new SelectList(db.TBL_PRIORIDAD, "PRI_ID", "PRI_NOMBRE");
            ViewBag.INC_USUARIO = new SelectList(db.TBL_USUARIO, "USU_ID", "USU_LOGIN");
            return View();
        }

        // POST: INCIDENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INC_ID,INC_FECHA,INC_VIGENCIA,INC_NUMTICKET,INC_COMENTARIO,INC_TIPO,INC_STATUS,INC_PRIORIDAD,INC_USUARIO,INC_ADD")] TBL_INCIDENTE tBL_INCIDENTE)
        {
            if (ModelState.IsValid)
            {
                db.TBL_INCIDENTE.Add(tBL_INCIDENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INC_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_INCIDENTE.INC_STATUS);
            ViewBag.INC_PRIORIDAD = new SelectList(db.TBL_PRIORIDAD, "PRI_ID", "PRI_NOMBRE", tBL_INCIDENTE.INC_PRIORIDAD);
            ViewBag.INC_USUARIO = new SelectList(db.TBL_USUARIO, "USU_ID", "USU_LOGIN", tBL_INCIDENTE.INC_USUARIO);
            return View(tBL_INCIDENTE);
        }

        // GET: INCIDENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_INCIDENTE tBL_INCIDENTE = db.TBL_INCIDENTE.Find(id);
            if (tBL_INCIDENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.INC_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_INCIDENTE.INC_STATUS);
            ViewBag.INC_PRIORIDAD = new SelectList(db.TBL_PRIORIDAD, "PRI_ID", "PRI_NOMBRE", tBL_INCIDENTE.INC_PRIORIDAD);
            ViewBag.INC_USUARIO = new SelectList(db.TBL_USUARIO, "USU_ID", "USU_LOGIN", tBL_INCIDENTE.INC_USUARIO);
            return View(tBL_INCIDENTE);
        }

        // POST: INCIDENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INC_ID,INC_FECHA,INC_VIGENCIA,INC_NUMTICKET,INC_COMENTARIO,INC_TIPO,INC_STATUS,INC_PRIORIDAD,INC_USUARIO,INC_ADD")] TBL_INCIDENTE tBL_INCIDENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_INCIDENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INC_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_INCIDENTE.INC_STATUS);
            ViewBag.INC_PRIORIDAD = new SelectList(db.TBL_PRIORIDAD, "PRI_ID", "PRI_NOMBRE", tBL_INCIDENTE.INC_PRIORIDAD);
            ViewBag.INC_USUARIO = new SelectList(db.TBL_USUARIO, "USU_ID", "USU_LOGIN", tBL_INCIDENTE.INC_USUARIO);
            return View(tBL_INCIDENTE);
        }

        // GET: INCIDENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_INCIDENTE tBL_INCIDENTE = db.TBL_INCIDENTE.Find(id);
            if (tBL_INCIDENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_INCIDENTE);
        }

        // POST: INCIDENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_INCIDENTE tBL_INCIDENTE = db.TBL_INCIDENTE.Find(id);
            db.TBL_INCIDENTE.Remove(tBL_INCIDENTE);
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
