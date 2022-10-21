using NHbDataAccessLayer;
using QuesAnsLib.Repositories.IRepository;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;

namespace QuesAnsLib.UnitOfWorks.Implementations
{
    class QuesAnsUnitOfWork : UnitOfWork, IQuesAnsUnitOfWork
    {
        public IUserRepository QuesAnsRepository { get; set; }
        public IQuestionRepository QuestionRepository { get; set; }
        public IAnswerRepository AnswerRepository { get; set; }

        public QuesAnsUnitOfWork(IUserRepository quesAnsRepository,
                                 IQuestionRepository questionRepository,
                                 IAnswerRepository answerRepository)
        {
            QuesAnsRepository = quesAnsRepository;
            QuestionRepository = questionRepository;
            AnswerRepository = answerRepository;
        }
    }
}
