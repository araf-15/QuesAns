using NHbDataAccessLayer;
using NHibernate;
using QuesAnsLib.Repositories.IRepository;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.UnitOfWorks.Implementations
{
    class QuesAnsUnitOfWork : UnitOfWork, IQuesAnsUnitOfWork
    {
        public IUserRepository QuesAnsRepository { get; set; }
        public IQuestionRepository QuestionRepository { get; set; }

        public QuesAnsUnitOfWork(IUserRepository quesAnsRepository,
                                 IQuestionRepository questionRepository)
        {
            QuesAnsRepository = quesAnsRepository;
            QuestionRepository = questionRepository;
        }
    }
}
