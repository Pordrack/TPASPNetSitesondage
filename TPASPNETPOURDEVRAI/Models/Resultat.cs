using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPASPNETPOURDEVRAI.Models
{
    public class Resultat
    {
        private string nom;
        private int nbVote;

        public int NbVote { get => nbVote; set => nbVote = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}