using System;
using System.ComponentModel.DataAnnotations;

namespace TPASPNETPOURDEVRAI.Models.Metadata
{
    public class SondageMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date;
    }
}