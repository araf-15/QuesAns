using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuesAnsLib.Repositories.Implementation
{
    public class AnswerRepository : Repository<Answer, Guid>, IAnswerRepository
    {
        public List<Answer> GetAnswersByQuestionId(Guid questionId)
        {
            var ansList = new List<Answer>();
            using (var session = _sessionFactory.OpenSession())
            {
                ansList = session.Query<Answer>().Where(c => c.QuestionId.ToString() == questionId.ToString()).ToList();
            }
            return ansList;
        }
    }
}
