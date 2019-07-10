using PI6_HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PI6_HelpDesk.Controllers
{
    public class HomeController : Controller
    {

        private MESA_SOPORTEEntities db = new MESA_SOPORTEEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TodosSoportes()
        {
            var soportes = db.TBL_INCIDENTE.ToList();
            return PartialView("_MostrarTodos", soportes);
       
        }
        public ActionResult MostrarSoportes(int id)
        {

            Incidente incidente = db.TBL_INCIDENTE.Find(INC_ID);

                }
    }
}