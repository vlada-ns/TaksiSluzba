using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public abstract class UserTS
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Field must be between 2 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Field must be between 6 and 20 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Field must be between 2 and 20 characters")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(1000000000000, 9999999999999, ErrorMessage = "Field must be number 13 characters long")]
        public long JMBG { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Field must be between 2 and 15 characters")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Field must be between 5 and 50 characters")]
        public string Email { get; set; }

        // My implemention does not require this field because I have entities Driver, Dispatcher and Customer
        // that Inherit class User. I leave this field as string, but if I must to use it, then maybe is
        // better to be of type enum Role { Driver, Dispatcher, Customer }
        public string Role { get; set; }

        public ICollection<Drive> Drives { get; set; }

    }
}