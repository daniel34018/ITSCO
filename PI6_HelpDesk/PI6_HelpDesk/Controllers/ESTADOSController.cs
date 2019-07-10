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
  //  [Authorize]
    public class ESTADOSController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: ESTADOS
        public ActionResult Index()
        {
            return View(db.TBL_ESTADO.ToList());
        }

        // GET: ESTADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ESTADO tBL_ESTADO = db.TBL_ESTADO.Find(id);
            if (tBL_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ESTADO);
        }

        // GET: ESTADOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EST_ID,EST_DESCRIPCION,EST_STATUS,EST_ADD")] TBL_ESTADO tBL_ESTADO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ESTADO.Add(tBL_ESTADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_ESTADO);
        }

        // GET: ESTADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ESTADO tBL_ESTADO = db.TBL_ESTADO.Find(id);
            if (tBL_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ESTADO);
        }

        // POST: ESTADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EST_ID,EST_DESCRIPCION,EST_STATUS,EST_ADD")] TBL_ESTADO tBL_ESTADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ESTADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_ESTADO);
        }

        // GET: ESTADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ESTADO tBL_ESTADO = db.TBL_ESTADO.Find(id);
            if (tBL_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ESTADO);
        }

        // POST: ESTADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ESTADO tBL_ESTADO = db.TBL_ESTADO.Find(id);
            db.TBL_ESTADO.Remove(tBL_ESTADO);
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
