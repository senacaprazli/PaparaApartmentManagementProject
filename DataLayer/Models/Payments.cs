using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Payments
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int BlockId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "PaymentType is required")]

        public string PaymentType { get; set; }
        [System.ComponentModel.DataAnnotations.Required]

        public int Payment { get; set; }
      [System.ComponentModel.DataAnnotations.Range(1, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
       // [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]

        public int Month { get; set; }
        [System.ComponentModel.DataAnnotations.Required]


        public int Year { get; set; }

        public bool Status { get; set; }
    }
}
