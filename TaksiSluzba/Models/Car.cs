using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public enum CarType {
        PassengerCar,
        Van
    };

    public class Car
    {
        [ForeignKey("Driver")]
        public int Id { get; set; }
        public int Year { get; set; }
        public string RegistrationPlate { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string TaxiNumber { get; set; }
        public CarType CarType { get; set; }

        public Driver Driver { get; set; }
    }
}