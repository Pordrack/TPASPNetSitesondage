using System;
using System.Collections.Generic;
using TPASPNETPOURDEVRAI.Models.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPASPNETPOURDEVRAI.Models.DAL;

namespace TPASPNETPOURDEVRAI.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var dal = new Dal())
            {
                return View(dal.RenvoieTousLesRestaurants());
            }
            
        }

        public ActionResult AfficherRestaurant(int? id)
        {
            using (var dal = new Dal())
            {
                if (id != null)
                {
                    return View(dal.RenvoieRestaurant((int)id));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ModifierRestaurant(int? id)
        {
            using (var dal = new Dal())
            {
                if (id != null)
                {
                    return View(dal.RenvoieRestaurant((int)id));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost] //HttpPost=Mode post formulaire
        [Authorize(Roles = "Admin")]
        public ActionResult ModifierRestaurant(Restaurant poResto)
        {
            if (!ModelState.IsValid)
                return View(poResto);

            using (var dal = new Dal())
            {
                dal.ModifierRestaurant(poResto.Id, poResto.Nom, poResto.Adresse, poResto.Telephone, poResto.Email);
            }

            return RedirectToAction("AfficherRestaurant/" + poResto.Id.ToString());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreerRestaurant()
        {
            return View();
        }

        [HttpPost] //HttpPost=Mode post formulaire
        [Authorize(Roles = "Admin")]
        public ActionResult CreerRestaurant(Restaurant poResto)
        {
            if (!ModelState.IsValid)
                return View(poResto);

            using (var dal = new Dal())
            {
                if (dal.RestaurantExist(poResto.Nom))
                {
                    ModelState.AddModelError("nom", "Le restaurant qui porte ce nom existe deja !");
                    return View(poResto);
                }
                dal.CreerRestaurant(poResto.Nom, poResto.Adresse, poResto.Telephone, poResto.Email);
            }

            return RedirectToAction("Index");
        }

        private readonly IDal _dal;
        public RestaurantController(IDal dal)
        {
            _dal = dal;
        }
    }
}