using System;
using System.Collections.Generic;
using System.Text;

namespace NHbDataAccessLayer.Entities
{
    public class Answer : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string AnswerDescription { get; set; }
        public virtual DateTime AnswerTime { get; set; }

        public virtual Guid AnswerById { get; set; }
        public virtual User AnswerBy { get; set; }
        public virtual Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
