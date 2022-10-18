using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Admin.Models;
using System;

namespace QuesAns.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsers()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            model.GetUserList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult AddUser(UserVM model)
        {
            model.AddUser();
            return RedirectToAction("AddUser");
        }

        [HttpGet]
        public IActionResult EditUser(Guid Id)
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            model.Id = Id;
            model.LoadtUser();
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult EditUser(UserVM model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateUser();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteUser(Guid Id)
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            model.Id = Id;
            model.DeleteUser();
            return RedirectToAction("Index");
        }
    }
}
