using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test_8.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UserProfile> UserInformations { get; set; }
        public object Image { get; internal set; }

        public UserContext() : base("UserConnection") { }
   
    
    }
}