using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Models.AccountModels;
using QuesAns.Utility;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class AccountController : Controller
    {
        #region Configure
        private readonly DropdownService _dropdownService;
        private readonly IDatabase _database;

        public AccountController(DropdownService dropdownService, IDatabase database)
        {
            _dropdownService = dropdownService;
            _database = database;
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
            var newUserId = await model.RegisterUser();
            if (newUserId != null)
            {
                model.Id = Guid.Parse(newUserId.ToString());
                model.PasswordHash = model.HashUserPassword(model.PasswordHash);
                model.AddUserCashedData(model.Email, model);
                return RedirectToAction("Login");
            }
            return RedirectToAction("Register");
        }
        #endregion

        #region Login
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Login(UserVM model)
        {
            var cashedData = model.GetUserCashData(model.Email);

            if (cashedData != null && cashedData.Email == model.Email
                && cashedData.PasswordHash == model.HashUserPassword(model.PasswordHash))
            {
                HttpContext.Session.SetString("Id", cashedData.Id.ToString());
                HttpContext.Session.SetString("UserName", cashedData.UserName);
                HttpContext.Session.SetString("UserType", cashedData.UserType);

                if(cashedData.UserType == "S") return RedirectToAction("Index", "Home", new { area = "Student" });
                else return RedirectToAction("Index", "Home", new { area = "Teacher" });
            }
            else
            {
                model.GetLoginUser();

                if (model.Id != Guid.Empty)
                {
                    HttpContext.Session.SetString("Id", model.Id.ToString());
                    HttpContext.Session.SetString("UserName", model.UserName);
                    HttpContext.Session.SetString("UserType", model.UserType);

                    model.AddUserCashedData(model.Email, new UserVM
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        InstituteName = model.InstituteName,
                        InstituteId = model.InstituteId,
                        PasswordHash = model.PasswordHash,
                        UserName = model.UserName,
                        UserType = model.UserType,
                        Email = model.Email
                    });
                    if (cashedData.UserType == "S") return RedirectToAction("Index", "Home", new { area = "Student" });
                    else return RedirectToAction("Index", "Home", new { area = "Teacher" });
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }
        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserType");
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        #endregion

        #region Helper Methods
        public bool CheckExistingUser(string userEmail)
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            var isExist = model.IsUserExist(userEmail);
            return isExist;
        }
        #endregion
    }
}
