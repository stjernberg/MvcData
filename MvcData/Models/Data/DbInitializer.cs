using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Data
{
    internal class DbInitializer
    {
        internal static async Task InitializeAsync(PeopleDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            context.Database.EnsureCreated();

           
            if (!context.Roles.Any())
            {
                //Create SuperAdmin role

                IdentityRole role = new IdentityRole("SuperAdmin");
                IdentityResult result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    ApplicationException exception = new ApplicationException($"Default role SuperAdmin cannot be created");
                    throw exception;
                }

                //Create user and add to SuperAdmin role
                AppUser appUser = new AppUser
                {
                    UserName = "SuperAdmin",
                    Email = "superadmin@app.com",
                    FirstName = "Super",
                    LastName = "SuperAdminSon",
                    BirthDate = DateTime.Now
                };

                IdentityResult userResult = await userManager.CreateAsync(appUser, "Super183?");

                if (!userResult.Succeeded)
                {
                    ApplicationException exception = new ApplicationException($"Default user SuperAdmin cannot be created");
                    throw exception;
                }

                userManager.AddToRoleAsync(appUser, role.Name).Wait();
            }


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                //Create Admin role
                IdentityRole adminRole = new IdentityRole("Admin");
                IdentityResult adminResult = await roleManager.CreateAsync(adminRole);

                if (!adminResult.Succeeded)
                {
                    ApplicationException exception = new ApplicationException($"Default role Admin cannot be created");
                    throw exception;
                }

                //Create user and add to Admin role
                AppUser appUser = new AppUser
                {
                    UserName = "Admin",
                    Email = "admin@app.com",
                    FirstName = "Admin",
                    LastName = "AdminSon",
                    BirthDate = DateTime.Now,
                };

                IdentityResult identityResult = await userManager.CreateAsync(appUser, "Admin352?");

                if (!identityResult.Succeeded)
                {
                    ApplicationException exception = new ApplicationException($"Default user Admin cannot be created");
                    throw exception;
                }

                userManager.AddToRoleAsync(appUser, adminRole.Name).Wait();
            }

        }
    }
}





