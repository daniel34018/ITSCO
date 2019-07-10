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
    public class ROLESController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: ROLES
        public ActionResult Index()
        {
            var tBL_ROL = db.TBL_ROL.Include(t => t.TBL_ESTADO);
            return View(tBL_ROL.ToList());
        }

        // GET: ROLES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ROL tBL_ROL = db.TBL_ROL.Find(id);
            if (tBL_ROL == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ROL);
        }

        // GET: ROLES/Create
        public ActionResult Create()
        {
            ViewBag.ROL_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            return View();
        }

        // POST: ROLES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROL_ID,ROL_DESCRIPCION,ROL_ADD,ROL_STATUS")] TBL_ROL tBL_ROL)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ROL.Add(tBL_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROL_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_ROL.ROL_STATUS);
            return View(tBL_ROL);
        }

        // GET: ROLES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ROL tBL_ROL = db.TBL_ROL.Find(id);
            if (tBL_ROL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROL_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_ROL.ROL_STATUS);
            return View(tBL_ROL);
        }

        // POST: ROLES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROL_ID,ROL_DESCRIPCION,ROL_ADD,ROL_STATUS")] TBL_ROL tBL_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ROL_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_ROL.ROL_STATUS);
            return View(tBL_ROL);
        }

        // GET: ROLES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ROL tBL_ROL = db.TBL_ROL.Find(id);
            if (tBL_ROL == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ROL);
        }

        // POST: ROLES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ROL tBL_ROL = db.TBL_ROL.Find(id);
            db.TBL_ROL.Remove(tBL_ROL);
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
