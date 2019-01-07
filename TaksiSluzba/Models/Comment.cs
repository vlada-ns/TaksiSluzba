using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }

        [Range(0, 5, ErrorMessage = "Grade must be number in range 1 - 5")]
        public int Grade { get; set; }

        public User User { get; set; }
        public Drive Drive { get; set; }

    }
}