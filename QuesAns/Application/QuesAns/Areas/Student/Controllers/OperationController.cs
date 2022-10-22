using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Student.Models;
using QuesAnsLib.Services.IServices;
using System;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Controllers
{
    [Area("Student")]
    public class OperationController : Controller
    {

        private readonly IQuesAnsService _quesAnsService;
        public OperationController()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var model = Startup.AutofacContainer.Resolve<QuestionVM>();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> MakeQuestion()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var model = Startup.AutofacContainer.Resolve<QuestionVM>();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MakeQuestion(QuestionVM model)
        {
            model.QuesTime = DateTime.Now;
            model.QuesById = Guid.Parse(HttpContext.Session.GetString("Id").ToString());
            var addedQuestion = await model.AddQuestion();

            model.AddQuestionToCashedData(addedQuestion.ToString(), new QuestionVM
            {
                Id = Guid.Parse(addedQuestion.ToString()),
                QuesTitle = model.QuesTitle,
                QuesDescription = model.QuesDescription,
                QuesTime = model.QuesTime,
                QuesById = model.QuesById,
                QuesBy = model.QuesBy

            });
            return RedirectToAction("MakeQuestion");
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








    }
}
