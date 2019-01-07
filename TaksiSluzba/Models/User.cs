using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        // TODO: Gender property type to be string or bool?
        public string Gender { get; set; }
        public int JMBG { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Drive> Drive { get; set; }

    }
}