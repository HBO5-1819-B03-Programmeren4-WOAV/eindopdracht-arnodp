using CExplorer.MVC.Data;
using CExplorer.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace CExplorer.MVC.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly CExplorerContext _Context;

        public LoginController (CExplorerContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var login = new LoginVm();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVm loginVm)
        {
            var user = _Context.Users.SingleOrDefault(g => g.Email == loginVm.EmailAdress);

            if(user != null)
                if(ModelState.IsValid)
                    if(string.Equals(user.Email, loginVm.EmailAdress, StringComparison.CurrentCultureIgnoreCase)
                        && loginVm.Password == user.Password)
                    {
                        ClaimsIdentity userIdentity;

                        if (user.IsAdmin)
                        {
                            userIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Email, user.Email),
                                    new Claim(ClaimTypes.Role, "Admin"),
                                },
                                "ApplicationCookie", ClaimTypes.Email, ClaimTypes.Role);
                        }
                        else
                        {
                            //Gewoone gebruikers
                            userIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Email, user.Email),
                                    new Claim(ClaimTypes.Role, "User"),
                                },
                                "ApplicationCookie", ClaimTypes.Email, ClaimTypes.Role);
                         }

                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        HttpContext.SignInAsync(principal);

                        if (principal.IsInRole("Admin"))
                        {
                            return new RedirectToActionResult("Index", "Admin", null);
                        }
                    }

            ModelState.AddModelError(string.Empty, "The given login information was not correct.");
            return View(loginVm);
        }
    }
}