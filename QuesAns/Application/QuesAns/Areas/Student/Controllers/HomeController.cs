using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        [Area("Student")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }


        public IActionResult MakeQuestion()
        {
            return View();
        }
    }
}
