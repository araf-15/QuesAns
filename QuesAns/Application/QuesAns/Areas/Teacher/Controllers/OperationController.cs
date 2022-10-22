using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Teacher.Models;
using QuesAnsLib.Services.IServices;
using System;
using System.Threading.Tasks;

namespace QuesAns.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class OperationController : Controller
    {
        private readonly IQuesAnsService _quesAnsService;

        public OperationController()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProvideAnswer(Guid questionId)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var model = Startup.AutofacContainer.Resolve<QuestionVM>();
                model.ConvertToSelf(questionId);
                var quesBy = _quesAnsService.GetUserEO(model.QuesById);
                model.QuesBy = quesBy;
                model.GetAnswerList(questionId);

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProvideAnswer(QuestionVM model)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                model.Answer.AsnwerTime = DateTime.Now;
                model.Answer.SubmitAnswer();

                return RedirectToAction("ProvideAnswer", new { questionId = Guid.Parse(model.Id.ToString())});
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }
    }
}
