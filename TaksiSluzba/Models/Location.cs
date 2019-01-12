using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }

        public Address Address { get; set; }

    }
}