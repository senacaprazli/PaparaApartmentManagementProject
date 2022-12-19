

//using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Occupants
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "name is required")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Surname is required")]

        public string Surname { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Block is required")]
        [System.ComponentModel.DataAnnotations.Range(1, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public int Block { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 11, ErrorMessage = "TCID must be 11 digits ")]
        public string TcId { get; set; }
      [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Password is required")]
       // [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]

        public string Password { get; set; }
        //  [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Phone is required")]
        [System.ComponentModel.DataAnnotations.Phone]

        public string Phone { get; set; }

        public string PlateNumber { get; set; }
       
    }
}
