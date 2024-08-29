using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.Domain.Entites
{
    public class Villa
    {
        public Guid VillaID { get; set; }
        public string VillaName { get; set; }
        public string VillaDescription { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageURL { get; set; }
        public string Amenity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }
        public ICollection<VillaNumber> VillaNumbers { get; set; } = new List<VillaNumber>();
    }
}
