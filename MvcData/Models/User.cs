using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models
{
    public class User : IdentityUser
    {
        
        public string LastName { get; set; }

        public string FirstName { get; set; }
       
        public DateTime BirthDate { get; set; }
    }
}
