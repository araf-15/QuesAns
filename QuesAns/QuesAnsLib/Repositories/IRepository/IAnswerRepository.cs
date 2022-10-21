using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Repositories.IRepository
{
    public interface IAnswerRepository : IRepository<Answer, Guid>
    {
        List<Answer> GetAnswersByQuestionId(Guid questionId);
    }
}
