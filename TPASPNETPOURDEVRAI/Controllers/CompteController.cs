using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TPASPNETPOURDEVRAI.Models.DAL;
using TPASPNETPOURDEVRAI.Models.Entity;

namespace TPASPNETPOURDEVRAI.Controllers
{
    public class CompteController : Controller
    {
        // GET: Compte
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            IdentitySignout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost] //HttpPost=Mode post formulaire
        public ActionResult Login(Eleve poEleve)
        {
            using (var dal = new Dal())
            {
                Eleve eleve=dal.Authentifier(poEleve.Nom, poEleve.Password);
                if (eleve != null)
                {
                    IdentitySignin(eleve);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("nom", "L'identifiant ou le mot de passe est erroné");
                    return View(poEleve);
                }
            }
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost] //HttpPost=Mode post formulaire
        public ActionResult CreateAccount(Eleve poEleve)
        {
            using (var dal = new Dal())
            {
                if (dal.EtudiantExist(poEleve.Nom) == null)
                {
                    dal.AjouterEtudiant(poEleve.Nom, poEleve.Prenom, poEleve.Password);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("nom", "Un etudiant avec ce nom existe deja, rajoute un nombre après");
                    return View(poEleve);
                }
            }
        }


        private void IdentitySignin(Eleve eleve)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, eleve.Id.ToString()),
                new Claim(ClaimTypes.Name, eleve.Nom)
            };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }
        private void IdentitySignout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
            DefaultAuthenticationTypes.ApplicationCookie,
            DefaultAuthenticationTypes.ExternalCookie
            );
        }
    }
}