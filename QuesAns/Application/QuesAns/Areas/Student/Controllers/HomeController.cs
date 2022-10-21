using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Student.Models;
using QuesAnsLib.Services.IServices;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        #region Configure
        private readonly IQuesAnsService _quesAnsService;

        public HomeController()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }
        #endregion


        [Area("Student")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var model = Startup.AutofacContainer.Resolve<QuestionVM>();
                model.GetQuestionList();
                return View(model);
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
