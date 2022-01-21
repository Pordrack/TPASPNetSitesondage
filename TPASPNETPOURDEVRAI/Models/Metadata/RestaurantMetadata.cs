using System;
using System.ComponentModel.DataAnnotations;

namespace TPASPNETPOURDEVRAI.Models.Metadata
{
    public class RestaurantMetadata
    {
        [Required(ErrorMessage ="Sale batard, tu me prend pour un con avec ton restaurant sans nom ?")]
        [StringLength(100)]
        public string Nom;

        [EmailAddress]
        [StringLength(150)]
        public string Email;

        [Required]
        [StringLength(250)]
        public string Adresse;

        [RegularExpression("^0[0-9]{9}$", ErrorMessage = "Entrez un numéro de téléphone au format français valide (commencant par 0)")]
        [StringLength(20)]
        [Display(Name = "Téléphone")]
        public string Telephone;
    }
}