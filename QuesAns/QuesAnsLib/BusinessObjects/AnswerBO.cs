using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.BusinessObjects
{
    public class AnswerBO
    {
        public Guid Id { get; set; }
        public string AnswerDescription { get; set; }
        public DateTime AsnwerTime { get; set; }

        //----------------Foreign Key-----------------
        public Guid AnsweById { get; set; }
        public User AnswerBy { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
