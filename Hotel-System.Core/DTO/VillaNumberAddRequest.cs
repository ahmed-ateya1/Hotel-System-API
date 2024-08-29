using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.DTO
{
    public class VillaNumberAddRequest
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Villa Number")]
        public int VillaNum { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Special Details")]
        public string SpecialDetails { get; set; }
        public Guid VillaID { get; set; }
    }
}
