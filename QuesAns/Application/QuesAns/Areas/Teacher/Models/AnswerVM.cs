using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Areas.Teacher.Models
{
    public class AnswerVM
    {
        public Guid Id { get; set; }
        public string AnswerDescription { get; set; }
        public string AsnwerTime { get; set; }

        //----------------Foreign Key-----------------
        public Guid AnsweById { get; set; }
        public User AnswerBy { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
