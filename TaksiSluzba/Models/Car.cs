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
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Field must be between 3 and 10 characters")]
        public string RegistrationPlate { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string TaxiNumber { get; set; }
        public CarType CarType { get; set; }

        public Driver Driver { get; set; }
    }
}