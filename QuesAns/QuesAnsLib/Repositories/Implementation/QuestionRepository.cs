using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using NHibernate.Criterion;
using NHibernate.Linq;
using QuesAnsLib.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuesAnsLib.Repositories.Implementation
{
    class QuestionRepository : Repository<Question, Guid>, IQuestionRepository
    {
        public List<Question> GetTestQuestions()
        {
            var questions = new List<Question>();
            using (var session = _sessionFactory.OpenSession())
            {
                questions = session.Query<Question>().Fetch(x => x.QuesBy).ToList();
                foreach (var question in questions)
                {
                    question.QuesBy = session.Query<User>().Where(c => c.Id.ToString() == question.QuesById.ToString()).FirstOrDefault();
                }
            }
            return questions;
        }
    }
}
