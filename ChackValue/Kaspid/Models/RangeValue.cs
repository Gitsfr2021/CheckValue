using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Kaspid.Models
{
    [Table(nameof(RangeValue))]
    public class RangeValue
    {
        #region Ctor
        public RangeValue()
        {
          
        }
        #endregion

        #region Properties
        [Key]
        public Int32 Id { get; set; }
        public long? Min { get; set; }
        public long? Max { get; set; }
        public bool Oprate1 { get; set; } = false;
        public bool Oprate2 { get; set; } = false;

        [Display(Name = "result")]
        [Required(ErrorMessage = "Enter {0}")]
        public long Result { get; set; }

        #endregion Properties
    }
}