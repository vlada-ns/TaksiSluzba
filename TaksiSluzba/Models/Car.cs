using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    // TODO: is enum best solution for CarType - enum is bad for run-time editing!
    public enum CarType {
        PassengerCar,
        Van
    };

    public class Car
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public int Year { get; set; }
        public string RegistrationPlate { get; set; }

        // TODO: property TaxiNumber is unique, does that mean it is [Required] too?
        [Index(IsUnique = true)]
        public string TaxiNumber { get; set; }
        public CarType CarType { get; set; }
    }
}