using TPASPNETPOURDEVRAI.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPASPNETPOURDEVRAI.Models.Entity
{
    [MetadataType(typeof(SondageMetadata))]
    public partial class Sondage : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valid = new List<ValidationResult>();
            if (Date<DateTime.Today)
                valid.Add(new ValidationResult("Marty! Je n'ai pas inventé la machine à voyager dans le temps pour aller au restaurant!", new[] { "Date" }));
            return valid;
        }
    }

    
}