using System;
using System.ComponentModel.DataAnnotations;

namespace TPASPNETPOURDEVRAI.Models.Metadata
{
    public class EleveMetadata
    {
        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        [StringLength(100,MinimumLength=7,ErrorMessage ="Le mot de passe doit faire entre 7 et 100 caracteres")]
        public string Password;

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom;

        [Required(ErrorMessage = "Le prenom est obligatoire")]
        public string Prenom;
    }
}