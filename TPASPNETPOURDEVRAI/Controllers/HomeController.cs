using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPASPNETPOURDEVRAI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            return View();
        }

        public ActionResult About(int? id)
        {
            ViewBag.Message = "C'est le about, qu'il est bien le about";
            ViewBag.Image="https://resize2.prod.docfr.doc-media.fr/s/1200/img/var/doctissimo/storage/images/fr/www/animaux/diaporamas/ratons-laveurs/2271839-1-fre-FR/Top-10-des-ratons-laveurs-les-plus-adorables.jpg";
            ViewBag.NumberOfRaccons = id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}