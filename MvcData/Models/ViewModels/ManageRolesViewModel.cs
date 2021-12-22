using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class ManageRolesViewModel
    {
        public IdentityRole Role { get; set; }
        public IList<AppUser> UserWithRole { get; set; }
        public IList<AppUser> UserNoRole { get; set; }
    }
}
