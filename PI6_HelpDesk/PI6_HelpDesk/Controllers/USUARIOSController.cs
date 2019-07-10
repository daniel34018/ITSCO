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
    public class USUARIOSController : Controller
    {
        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        // GET: USUARIOS
        public ActionResult Index()
        {
            var tBL_USUARIO = db.TBL_USUARIO.Include(t => t.TBL_ESTADO).Include(t => t.TBL_PERSONA).Include(t => t.TBL_ROL);
            return View(tBL_USUARIO.ToList());
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_USUARIO);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            ViewBag.USU_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION");
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION");
            ViewBag.ROL_ID = new SelectList(db.TBL_ROL, "ROL_ID", "ROL_DESCRIPCION");
            return View();
        }

        // POST: USUARIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USU_ID,ROL_ID,PER_ID,USU_LOGIN,USU_PASSWORD,USU_EMAIL,USU_ADD,USU_STATUS")] TBL_USUARIO tBL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_USUARIO.Add(tBL_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USU_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_USUARIO.USU_STATUS);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_USUARIO.PER_ID);
            ViewBag.ROL_ID = new SelectList(db.TBL_ROL, "ROL_ID", "ROL_DESCRIPCION", tBL_USUARIO.ROL_ID);
            return View(tBL_USUARIO);
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USU_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_USUARIO.USU_STATUS);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_USUARIO.PER_ID);
            ViewBag.ROL_ID = new SelectList(db.TBL_ROL, "ROL_ID", "ROL_DESCRIPCION", tBL_USUARIO.ROL_ID);
            return View(tBL_USUARIO);
        }

        // POST: USUARIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USU_ID,ROL_ID,PER_ID,USU_LOGIN,USU_PASSWORD,USU_EMAIL,USU_ADD,USU_STATUS")] TBL_USUARIO tBL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USU_STATUS = new SelectList(db.TBL_ESTADO, "EST_ID", "EST_DESCRIPCION", tBL_USUARIO.USU_STATUS);
            ViewBag.PER_ID = new SelectList(db.TBL_PERSONA, "PER_ID", "PER_TIPOIDENTIFICACION", tBL_USUARIO.PER_ID);
            ViewBag.ROL_ID = new SelectList(db.TBL_ROL, "ROL_ID", "ROL_DESCRIPCION", tBL_USUARIO.ROL_ID);
            return View(tBL_USUARIO);
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_USUARIO);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            db.TBL_USUARIO.Remove(tBL_USUARIO);
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
