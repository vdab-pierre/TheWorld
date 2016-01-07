using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using TheWorld.Models;
using TheWorld.ViewModel;

namespace TheWorld.Controllers
{
    public class AuthController:Controller
    {
        private SignInManager<WorldUser> _signinManager;

        public AuthController(SignInManager<WorldUser> signinManager)
        {
            _signinManager = signinManager;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("~/App/Trips");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signinManager.PasswordSignInAsync(vm.Username,
                    vm.Password,
                    true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Trips", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect");
                }
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signinManager.SignOutAsync();
            }
            return RedirectToAction("Index", "App");
        }
    }
}
