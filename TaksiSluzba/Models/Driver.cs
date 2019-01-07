using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Driver : User
    {
        public Location Location { get; set; }
        public string Car { get; set; }
    }
}