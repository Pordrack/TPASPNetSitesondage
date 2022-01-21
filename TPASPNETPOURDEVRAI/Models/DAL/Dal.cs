﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            throw new NotImplementedException();
        }

        public int AjouterVote(int idSondage, int idResto, int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Eleve Authentifier(string nom, string password)
        {
            throw new NotImplementedException();
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

        public int CreerSondage(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email)
        {rerty
            throw new NotImplementedException();
        }

        public Eleve RenvoieEtudiant(int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Restaurant RenvoieRestaurant(int idRestaurant)
        {
            throw new NotImplementedException();
        }

        public IList<Resultat> RenvoieResultat(int idSondage)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> RenvoieTousLesRestaurants()
        {
            throw new NotImplementedException();
        }

        public bool RestaurantExist(string nom)
        {
            return mySoireeContext.Restaurants.Where(r=>r.Nom==nom).Count()>0;
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