using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using UnivPortal.Models;


namespace UnivPortal.Controllers
{
    public class AccountManagementController : Controller
    {
        /*
       public AccountManagementController() { }

        private ApplicationUserManager _userManager;

       

        public AccountManagementController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
       //
       // GET: /AccountManagement/Login
       [AllowAnonymous]
       public ActionResult Login(string returnUrl)
       {
           ViewBag.ReturnUrl = returnUrl;
           return View();
       }

       //
       // POST: /AccountManagement/Login
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Login(Login1ViewModel model, string returnUrl)
       {
           if (ModelState.IsValid)
           {
               var user = await UserManager.FindAsync(model.Email, model.Password);
               if (user != null)
               {
                   await SignInAsync(user, model.RememberMe);
                   return RedirectToLocal(returnUrl);
               }
               else
               {
                   ModelState.AddModelError("", "Invalid username or password.");
               }
           }

           // If we got this far, something failed, redisplay form
           return View(model);
       }
       private IAuthenticationManager AuthenticationManager
       {
           get
           {
               return HttpContext.GetOwinContext().Authentication;
           }
       }
       private async Task SignInAsync(ApplicationUser user, bool isPersistent)
       {
           AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
           AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
       }

       private ActionResult RedirectToLocal(string returnUrl)
       {
           if (Url.IsLocalUrl(returnUrl))
           {
               return Redirect(returnUrl);
           }
           else
           {
               return RedirectToAction("Index", "Home");
           }
       }

       //
       // GET: /Account/Register
       [AllowAnonymous]
       public ActionResult Register()
       {
           return View();
       }

       //
       // POST: /Account/Register
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Register(RegisterUserViewModel model)
       {
           if (ModelState.IsValid)
           {
               var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
               IdentityResult result = await UserManager.CreateAsync(user, model.Password);
               if (result.Succeeded)
               {
                   await SignInAsync(user, isPersistent: false);

                   // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                   // Send an email with this link
                   // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                   // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                   // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                   return RedirectToAction("Index", "Home");
               }
               else
               {
                   AddErrors(result);
               }
           }

           // If we got this far, something failed, redisplay form
           return View(model);
       }

       private void AddErrors(IdentityResult result)
       {
           foreach (var error in result.Errors)
           {
               ModelState.AddModelError("", error);
           }
       }

       private bool HasPassword()
       {
           var user = UserManager.FindById(User.Identity.GetUserId());
           if (user != null)
           {
               return user.PasswordHash != null;
           }
           return false;
       }
       public ActionResult LogOff()
       {
           AuthenticationManager.SignOut();
           return RedirectToAction("Index", "Home");
       }*/
    }
}