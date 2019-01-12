using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Driver : User
    {
        public bool Blocked { get; set; }

        public Car Car { get; set; }
        public Location Location { get; set; }
    }
}