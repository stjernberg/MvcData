using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcData.Models;
using System.Text;
using MvcData.Models.ViewModels;

namespace MvcData.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole(name);

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            String message = ("Errors: ");

            foreach (var item in result.Errors)
            {
                message += item.Description + (" ");
            }

            ViewBag.Msg = message;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string id, string msg = null)
        {
           
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            ManageRolesViewModel rolesViewModel = new ManageRolesViewModel();

            rolesViewModel.Role = role;

            rolesViewModel.UserWithRole = await _userManager.GetUsersInRoleAsync(role.Name);

            rolesViewModel.UserNoRole = _userManager.Users.ToList();

            foreach (var item in rolesViewModel.UserWithRole)
            {
                rolesViewModel.UserNoRole.Remove(item);
            }

            ViewBag.Msg = msg;
            return View(rolesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddToRole(string userId, string roleId)
        {
            
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUserRoles), new { msg = "User has successfully been added to the role", id = role.Id });
            }

           
            return RedirectToAction(nameof(ManageUserRoles), new { msg = "Failed to add user to the role", id = role.Id });
           
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
          

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ManageUserRoles), new { msg = "User has successfully been removed from the role", id = role.Id });
            }

           
            return RedirectToAction(nameof(ManageUserRoles), new { msg = "Failed to remove user from the role", id = role.Id });
        }
    }
}
