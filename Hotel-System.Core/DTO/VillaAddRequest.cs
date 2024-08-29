using System.ComponentModel.DataAnnotations;

namespace Hotel_System.Core.DTO
{
    public class VillaAddRequest
    {
        [Required(ErrorMessage = "Villa Name is required.")]
        [MaxLength(100, ErrorMessage = "Villa Name cannot exceed 100 characters.")]
        public string VillaName { get; set; }

        [MaxLength(500, ErrorMessage = "Villa Description cannot exceed 500 characters.")]
        public string VillaDescription { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Rate must be greater than 0.")]
        public double Rate { get; set; }

        [Required(ErrorMessage = "Square footage (Sqft) is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sqft must be a positive number.")]
        public int Sqft { get; set; }

        [Required(ErrorMessage = "Occupancy is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Occupancy must be a positive number.")]
        public int Occupancy { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Invalid URL format for Image URL.")]
        public string ImageURL { get; set; }

        [MaxLength(200, ErrorMessage = "Amenity description cannot exceed 200 characters.")]
        public string Amenity { get; set; }
    }
}
