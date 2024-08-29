using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.DTO
{
    public class VillaNumberResponse
    {
        [Display(Name = "Villa Number")]
        public int VillaNum { get; set; }
        [Display(Name = "Special Details")]
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid VillaID { get; set; }
        public string VillaName { get; set; }
    }
}
