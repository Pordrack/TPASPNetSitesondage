using System;
using System.Collections.Generic;
using TPASPNETPOURDEVRAI.Models.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPASPNETPOURDEVRAI.Models.DAL;

namespace TPASPNETPOURDEVRAI.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreerRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerRestaurant(Restaurant poResto)
        {
            if (!ModelState.IsValid)
                return View(poResto);

            using (var dal = new Dal())
            {
                if (dal.RestaurantExist(poResto.Nom))
                {
                    return View(poResto);
                }
                dal.CreerRestaurant(poResto.Nom, poResto.Adresse, poResto.Telephone, poResto.Email);
            }

                return View();
        }
    }
}