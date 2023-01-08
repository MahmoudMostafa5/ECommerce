using Ecommerce.BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly SignInManager<IdentityUser> signManager;
        private readonly ILogger<HomeController> logger;

        public AccountController(UserManager<IdentityUser> usermanager , SignInManager<IdentityUser> signManager,ILogger<HomeController> logger)
        {
            this.usermanager = usermanager;
            this.signManager = signManager;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await usermanager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(model);
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var res = await signManager.PasswordSignInAsync(model.userName, model.Password, model.Remember, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName OR Password InValid");
                }
            }
            return View(model);
        }
        
        public IActionResult LogOut()
        {
            signManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await usermanager.GeneratePasswordResetTokenAsync(user);

                    var passResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, passResetLink);

                    return RedirectToAction("ConfirmForgetPassword");

                }
                return View(model);
            }
            return View();
        }

        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
        
        public IActionResult ResetPassword(string Email , string Token)
        {
            if (Email == null || Token == null)
            {
                ModelState.AddModelError("", "InValid Email , Token");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var res = await usermanager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("LogIn");
                    }
                                      
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
                return RedirectToAction("LogIn");
            }

            return View(model);
        }

    }
}
