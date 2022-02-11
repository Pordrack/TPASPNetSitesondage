using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPASPNETPOURDEVRAI.Models.DAL;
using TPASPNETPOURDEVRAI.Models.Entity;

namespace TPASPNETPOURDEVRAI.Controllers
{
    [Authorize]
    public class SondageController : Controller
    {
        // GET: Sondage
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var dal = new Dal())
            {
                return View(dal.RenvoieTousLesSondages());
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreerSondage()
        {
            return View();
        }

        [HttpPost] //HttpPost=Mode post formulaire
        [Authorize(Roles = "Admin")]
        public ActionResult CreerSondage(Sondage poSondage)
        {
            if (!ModelState.IsValid)
                return View(poSondage);

            using (var dal = new Dal())
            {
                if (dal.SondageExiste(poSondage.Date))
                {
                    ModelState.AddModelError("Date","Un seul sondage par date !");
                    return View(poSondage);
                }
                dal.CreerSondage(poSondage.Date);
            }

            return RedirectToAction("Index");
        }
    }
}