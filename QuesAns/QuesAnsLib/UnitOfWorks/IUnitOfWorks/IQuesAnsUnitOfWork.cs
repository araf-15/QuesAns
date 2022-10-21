using NHbDataAccessLayer;
using QuesAnsLib.Repositories.IRepository;

namespace QuesAnsLib.UnitOfWorks.IUnitOfWorks
{
    public interface IQuesAnsUnitOfWork : IUnitOfWork
    {
        IUserRepository QuesAnsRepository { get; set; }
        IQuestionRepository QuestionRepository { get; set; }
        IAnswerRepository AnswerRepository { get; set; }
    }
}
