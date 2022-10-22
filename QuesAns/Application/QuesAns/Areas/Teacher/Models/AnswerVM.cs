using Autofac;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Areas.Teacher.Models
{
    public class AnswerVM
    {
        #region Configuration
        private readonly IQuesAnsService _quesAnsService;

        public AnswerVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }

        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string AnswerDescription { get; set; }
        public DateTime AsnwerTime { get; set; }

        //----------------Foreign Key-----------------
        public Guid AnsweById { get; set; }
        public User AnswerBy { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        #endregion

        #region Methods
        public void SubmitAnswer()
        {
            var answerBO = ConvertToBOAnswer();
            _quesAnsService.AddAnswer(answerBO);
        }
        #endregion


        #region Helper Method
        private AnswerBO ConvertToBOAnswer()
        {
            var questionBo = new AnswerBO
            {
                Id = Id,
                AnsweById = AnsweById,
                AnswerDescription = AnswerDescription,
                AsnwerTime = AsnwerTime,
                QuestionId = QuestionId,
            };
            return questionBo;
        }
        #endregion
    }
}
