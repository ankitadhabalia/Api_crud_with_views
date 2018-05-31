using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_8.Models
{
    public class UserProfile
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Marital_Status { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
        public string Action { get; set; }

    }
}