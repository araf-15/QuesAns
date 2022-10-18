using Autofac;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Models.AccountModels;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class AccountController : Controller
    {
        #region Configure



        #endregion

        #region Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
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
        //public async Task<IActionResult> Login(string returnUrl = null)
        //{
        //    var model = new LoginModel();
        //    if (!string.IsNullOrEmpty(model.ErrorMessage))
        //    {
        //        ModelState.AddModelError(string.Empty, model.ErrorMessage);
        //    }

        //    returnUrl = returnUrl ?? Url.Content("~/");

        //    // Clear the existing external cookie to ensure a clean login process
        //    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        //    model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    model.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");

        //    if (ModelState.IsValid)
        //    {

        //        var user = await _userManager.FindByEmailAsync(model.Email);

        //        if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
        //        {
        //            ModelState.AddModelError(string.Empty, "Email not confirmed yet");
        //            return View(model);
        //        }

        //        // This doesn't count login failures towards account lockout
        //        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        //        if (result.Succeeded)
        //        {
        //            _logger.LogInformation("User logged in.");
        //            return LocalRedirect(returnUrl);
        //        }
        //        if (result.RequiresTwoFactor)
        //        {
        //            return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //        }
        //        if (result.IsLockedOut)
        //        {
        //            _logger.LogWarning("User account locked out.");
        //            return RedirectToPage("./Lockout");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //            return View(model);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
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
