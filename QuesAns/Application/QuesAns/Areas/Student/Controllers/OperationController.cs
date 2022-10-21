﻿using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesAns.Areas.Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Controllers
{
    [Area("Student")]
    public class OperationController : Controller
    {

        #region Configuration
        

        #endregion


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
        public async Task<IActionResult>  MakeQuestion()
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




    }
}