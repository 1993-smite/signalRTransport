using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Shower.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Rabbit.Shower.Controllers
{
    [Authorize]
    public class AccountController : AuthorizedController
    {
        public IActionResult Index()
        {
            SetAuthViewData();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(AccountView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.Login)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync("Cookie", claimsPrincipal);

            return Redirect(model.ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookie");

            return Redirect("/");
        }
    }
}
