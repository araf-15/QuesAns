using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        [Area("Student")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
