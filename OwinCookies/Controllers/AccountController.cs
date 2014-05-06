using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OwinCookies.Models;

namespace OwinCookies.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if(model.UserName == model.Password)//validate username/password here.
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Cecil"),
                    new Claim(ClaimTypes.Email, "dont-email-me@gmail.com")
                };
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = this.Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                var props = new AuthenticationProperties //this is optional
                {
                    IsPersistent = false
                };
                authenticationManager.SignIn(props, id);
                return Redirect(returnUrl);
            }
            return View();
        }
    }
}