using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class User: AComponents
    {
        public string username { get; set; }
        public string password { get; set;}
        public string lastname { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        // public string type { get; set; }

        public User(){}
    }
}