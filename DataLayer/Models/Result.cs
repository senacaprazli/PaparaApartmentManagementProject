﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public  class Result
    {
        public int HttpStatusCode { get; set; }
        public string? Message{ get; set; }
    }
}
