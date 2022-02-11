using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using TPASPNETPOURDEVRAI.Models.Entity;

namespace TPASPNETPOURDEVRAI.Models.DAL
{
    public class Dal : IDal
    {
        private SoireeContext mySoireeContext;
        public Dal()
        {
            mySoireeContext = new SoireeContext();
        }

        public int AjouterEtudiant(string nom, string prenom, string password)
        {
            Eleve eleve = new Eleve();
            eleve.Nom = nom;
            eleve.Prenom = prenom;
            eleve.Password = Crypto.HashPassword(password);

            mySoireeContext.Eleves.Add(eleve);
            mySoireeContext.SaveChanges();
            return 1;
        }

        public int AjouterVote(int idSondage, int idResto, int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Eleve Authentifier(string nom, string password)
        {
            //string hashedPassword = Crypto.HashPassword(password);
            Eleve eleve = mySoireeContext.Eleves.FirstOrDefault(e => e.Nom == nom);// && hashedPassword==e.Password);
            //return eleve;
            if(Crypto.VerifyHashedPassword(eleve.Password, password))
            {
                return eleve;
            }
            else
            {
                return null;
            }
            
        }

        public int CreerRestaurant(string nom, string adresse, string telephone, string email)
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.Nom = nom;
            newRestaurant.Adresse = adresse;
            newRestaurant.Telephone = telephone;
            newRestaurant.Email = email;
            mySoireeContext.Restaurants.Add(newRestaurant);
            mySoireeContext.SaveChanges();
            return 1;
        }

        public IList<Sondage> RenvoieTousLesSondages()
        {
            return mySoireeContext.Sondages.ToList();
        }

        public int CreerSondage(DateTime date)
        {
            Sondage newSondage = new Sondage();
            newSondage.Date = date;
            mySoireeContext.Sondages.Add(newSondage);
            mySoireeContext.SaveChanges();
            return 1;
        }

        public bool SondageExiste(DateTime date)
        {
            return mySoireeContext.Sondages.Any(s => s.Date == date);
        }

        public void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email)
        {
            Restaurant restoAModifier = mySoireeContext.Restaurants.Find(idResto);
            restoAModifier.Nom = nom;
            restoAModifier.Adresse = adresse;
            restoAModifier.Telephone = telephone;
            restoAModifier.Email = email;
            mySoireeContext.SaveChanges();
        }

        public Eleve RenvoieEtudiant(int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Eleve EtudiantExist(string nomEtudiant)
        {
            return mySoireeContext.Eleves.FirstOrDefault(e => e.Nom == nomEtudiant);
        }

        public Restaurant RenvoieRestaurant(int idRestaurant)
        {
            return mySoireeContext.Restaurants.Find(idRestaurant);
        }

        public IList<Resultat> RenvoieResultat(int idSondage)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> RenvoieTousLesRestaurants()
        {
            return mySoireeContext.Restaurants.ToList();
        }

        public bool RestaurantExist(string nom)
        {
            return mySoireeContext.Restaurants.Any(r=>r.Nom==nom);
        }

        public bool VoteExist(int idSondage, int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            mySoireeContext.Dispose();
        }
    }
}