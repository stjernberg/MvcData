using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models
{
    public class AppUser : IdentityUser
    {
        
        public string LastName { get; set; }

        public string FirstName { get; set; }
       
        public DateTime BirthDate { get; set; }
    }
}
