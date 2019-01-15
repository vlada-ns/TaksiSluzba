using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AddressId { get; set; }

        [InverseProperty("Location")]
        public IList<Drive> DriveLocations { get; set; }

        [InverseProperty("Destination")]
        public IList<Drive> DriveDestinations { get; set; }

    }
}