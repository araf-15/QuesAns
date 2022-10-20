using Autofac;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
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
        #endregion

        private readonly IQuesAnsService _quesAnsService;

        public QuestionVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }

        #region Methods
        public async Task<object> AddQuestion()
        {
            var questionBO = ConvertToBOQuestion();
            return await _quesAnsService.AddQuestion(questionBO);
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
    }
}
