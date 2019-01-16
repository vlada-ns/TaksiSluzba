using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Comment
    {
        [ForeignKey("Drive")]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "Field must be between 2 and 200 characters")]
        public string Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Range(0, 5, ErrorMessage = "Grade must be number in range 1 - 5")]
        public int Grade { get; set; } = 0;

        public UserTS UserTS { get; set; }
        public Drive Drive { get; set; }

    }
}