using NHbDataAccessLayer.Entities;
using QuesAnsLib.Services.IServices;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace QuesAnsLib.Services.Implementations
{
    public class QuesAnsService : IQuesAnsService
    {
        private readonly IQuesAnsUnitOfWork _quesAnsUnitOfWork;

        public QuesAnsService(IQuesAnsUnitOfWork quesAnsUnitOfWork)
        {
            _quesAnsUnitOfWork = quesAnsUnitOfWork;
        }

        public List<User> GetUserList()
        {
            var userList = _quesAnsUnitOfWork.QuesAnsRepository.GetAll().ToList();
            return userList;
        }
    }
}
