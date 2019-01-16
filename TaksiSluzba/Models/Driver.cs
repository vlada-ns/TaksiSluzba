using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Driver : UserTS
    {
        public bool Blocked { get; set; }

        public Car Car { get; set; }

        // TODO: Driver LocationId to be nullable int?
        // If driver can be without location then correct type is int?
        public Location Location { get; set; }
        public int? LocationId { get; set; }
    }
}