﻿using Autofac;
using NHbDataAccessLayer.Entities;
using QuesAns.Utility;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.Implementations;
using QuesAnsLib.Services.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Areas.Student.Models
{
    public class QuestionVM
    {
        #region Property
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please write a question title")]
        public string QuesTitle { get; set; }
        public string QuesDescription { get; set; }
        public DateTime QuesTime { get; set; }

        //--------------FK------------------------------
        public Guid QuesById { get; set; }
        public User QuesBy { get; set; }

        public IList<QuestionVM> Questions { get; set; }

        #endregion

        private readonly IQuesAnsService _quesAnsService;
        private readonly ICashService<string, QuestionVM> _iCashService;
        private readonly ApplicationService _applicationService;


        public QuestionVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
            _iCashService = Startup.AutofacContainer.Resolve<ICashService<string, QuestionVM>>();
            _applicationService = Startup.AutofacContainer.Resolve<ApplicationService>();
        }

        #region Methods
        public async Task<object> AddQuestion()
        {
            var questionBO = ConvertToBOQuestion();
            return await _quesAnsService.AddQuestion(questionBO);
        }

        public async void GetQuestionList()
        {
            var questions = _quesAnsService.GetQuestionList();
            Questions = new List<QuestionVM>();
            if (questions.Count > 0)
            {
                foreach (var question in questions)
                {
                    var questionVM = new QuestionVM
                    {
                        Id = question.Id,
                        QuesTitle = question.QuesTitle,
                        QuesDescription = _applicationService.
                                          MinifyQuestionDescription(question.QuesDescription),
                        QuesTime = question.QuesTime,
                        QuesById = question.QuesById,
                        QuesBy = question.QuesBy
                    };
                    Questions.Add(questionVM);
                }
            }
        }

        private QuestionBO ConvertToBOQuestion()
        {
            var questionBo = new QuestionBO
            {
                Id = Id,
                QuesTitle = QuesTitle,
                QuesDescription = QuesDescription,
                QuesTime = QuesTime,
                QuesById = QuesById
            };
            return questionBo;
        }

        #endregion


        #region CashedData Methods
        public void AddQuestionToCashedData(string key, QuestionVM modelValue)
        {
            _iCashService.Add(key, modelValue);
        }
        #endregion
    }
}
