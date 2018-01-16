using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Blog.Models;
using Blog.Data.Model;
using Blog.AdditionalInfrastructure.IdentityConfiguration;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            var amw = new AuthorizeModelWrapper();

            return View(amw);
        }

        [HttpPost]
        public ActionResult SignIn(AuthorizeModel mainContent)
        {
            var amw = new AuthorizeModelWrapper();
            if (ModelState.IsValid)
            {
                _signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                var result = _signInManager.PasswordSignIn(mainContent.UserName, mainContent.Password, mainContent.IsRememberMe, shouldLockout: false);

                if (result.Equals(SignInStatus.Success))
                {
                    return RedirectToAction("Index", "Home", amw);
                }
                else
                {
                    ModelState.AddModelError("", "Учетная запись незарегистрирована");
                }
            }

            return View(amw);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var rmw = new RegistrationModelWrapper();

            return View(rmw);
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel mainContent)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = mainContent.UserName, Email = mainContent.Email };

                var creationResult = _userManager.Create(user, mainContent.Password);

                if (creationResult.Succeeded)
                {
                    var addToRoleResult = _userManager.AddToRole(user.Id, "User");
                    if (addToRoleResult.Succeeded)
                    {
                        var amw = new AuthorizeModelWrapper();
                        return RedirectToAction("SignIn", "Account", amw);
                    }
                }
            }

            var rmw = new RegistrationModelWrapper();

            return View(rmw);
        }

        [HttpGet]
        [Authorize]
        public ActionResult SignOut()
        {
            _signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        private BlogUserManager _userManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<BlogUserManager>(); }
        }

        private BlogSignInManager _signInManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<BlogSignInManager>(); }
        }
    }
}