using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Repositories.IRepository
{
    public interface IQuestionRepository : IRepository<Question, Guid>
    {
        public List<Question> GetTestQuestions();
    }
}
