using Autofac;
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

namespace QuesAns.Areas.Teacher.Models
{
    public class QuestionVM
    {
        #region Property
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please write a question title")]
        public string QuesTitle { get; set; }
        public string QuesDescription { get; set; }
        public DateTime QuesTime { get; set; }
        public AnswerVM Answer { get; set; }

        //--------------FK------------------------------
        public Guid QuesById { get; set; }
        public User QuesBy { get; set; }

        public IList<QuestionVM> Questions { get; set; }
        public IList<AnswerVM> Answers { get; set; }

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

        public void GetAnswerList(Guid questionId)
        {
            var answersEO = _quesAnsService.GetAnswers(questionId);
            Answers = new List<AnswerVM>();
            foreach (var answer in answersEO)
            {
                var answerVM = new AnswerVM();

                answerVM.Id = answer.Id;
                answerVM.AnswerDescription = answer.AnswerDescription;
                answerVM.AsnwerTime = answer.AnswerTime;
                answerVM.AnsweById = answer.AnswerById;
                answerVM.QuestionId = answer.QuestionId;
                var userEO = _quesAnsService.GetUserEO(answer.AnswerById);
                answerVM.AnswerBy = userEO;

                Answers.Add(answerVM);
            }
        }

        public void ConvertToSelf(Guid questionId)
        {
            var question = _quesAnsService.GetQuestion(questionId);

            Id = question.Id;
            QuesTitle = question.QuesTitle;
            QuesDescription = question.QuesDescription;
            QuesTime = question.QuesTime;
            QuesById = question.QuesById;
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
