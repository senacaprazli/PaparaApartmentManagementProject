

namespace DataLayer.Models
{
    public class Blocks
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Block is required")]

        public int Block { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "FlatStatus is required")]

        public string FlatStatus { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Type is required")]

        public string Type { get; set; }
        [System.ComponentModel.DataAnnotations.Range(1, 50, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public int Floor { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "FlatNumber is required")]
        [System.ComponentModel.DataAnnotations.Range(1, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public int FlatNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "OwnerOrTenant is required")]

        public string OwnerOrTenant { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Occupant is required")]

        public string Occupant { get; set; }
    }
}
