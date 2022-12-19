using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Messages
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int OccupantId { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public string Time { get; set; }
    }
}
