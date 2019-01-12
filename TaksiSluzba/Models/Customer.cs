using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaksiSluzba.Models
{
    public class Customer : User
    {
        public bool Blocked { get; set; }
        // Number of bonus points - every drive is 1 point, after 9 colected points next drive is free
        public int BonusPoints { get; set; }

    }
}