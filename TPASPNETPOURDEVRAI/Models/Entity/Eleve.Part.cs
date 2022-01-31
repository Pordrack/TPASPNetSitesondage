using TPASPNETPOURDEVRAI.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPASPNETPOURDEVRAI.Models.Entity
{
    [MetadataType(typeof(EleveMetadata))]
    public partial class Eleve : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valid = new List<ValidationResult>();
            return valid;
        }
    }

    
}