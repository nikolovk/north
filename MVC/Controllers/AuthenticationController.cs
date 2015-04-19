using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel input)
        {
            if (ModelState.IsValid)
            {
                if (input.HasValidUsernameAndPassword)
                {
                    var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, input.Username),
                        },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name, ClaimTypes.Role);

                    // if you want roles, just add as many as you want here (for loop maybe?)
                    identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));
                    // tell OWIN the identity provider, optional
                    // identity.AddClaim(new Claim(IdentityProvider, "Simplest Auth"));

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = input.RememberMe
                    }, identity);

                    return RedirectToAction("index", "home");
                }
            }

            return View("show", input);
        }

        public ActionResult Logout()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login");
        }

    }
}