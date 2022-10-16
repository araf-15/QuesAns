using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Admin.Models;

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
    }
}
