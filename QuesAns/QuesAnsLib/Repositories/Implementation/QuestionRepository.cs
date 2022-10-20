using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Repositories.Implementation
{
    class QuestionRepository : Repository<Question, Guid>, IQuestionRepository
    {
    }
}
