using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcData.Models;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    BirthDate = registerUser.BirthDate,
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,                 

                };

                IdentityResult result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }
            }
            return View(registerUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userLogin)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);

            if (result.IsNotAllowed)
            {
                ViewBag.Msg = "You're not alllowed to login.";
            }
            if (result.IsLockedOut)
            {
                ViewBag.Msg = "You're locked out from login.";
            }
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}
