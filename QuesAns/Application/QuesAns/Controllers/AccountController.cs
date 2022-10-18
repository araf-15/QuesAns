using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Models.AccountModels;
using QuesAns.Utility;
using System;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class AccountController : Controller
    {
        #region Configure
        private readonly DropdownService _dropdownService;

        public AccountController(DropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }

        #endregion

        #region Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            model.UserTypeLookup = _dropdownService.GetUserTypeSelectListItems();
            return View(model);
        }


        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {

            await model.RegisterUser();
            return RedirectToAction("Register");
        }
        #endregion



        #region Login
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            //HttpContext.Session.SetString("Role", "T");
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Login(UserVM model)
        {
            model.GetLoginUser();

            if(model.Id != Guid.Empty)
            {
                HttpContext.Session.SetString("Id", model.Id.ToString());
                HttpContext.Session.SetString("UserName", model.UserName);
                HttpContext.Session.SetString("UserType", model.UserType);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        
        #endregion


        #region Logout
        //public async Task<IActionResult> Logout(string returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();
        //    //_logger.LogInformation("User logged out.");
        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
        #endregion
    }
}
