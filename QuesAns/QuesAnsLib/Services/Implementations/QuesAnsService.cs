using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;
using System.Collections.Generic;
using System.Linq;
using BO = QuesAnsLib.BusinessObjects;

namespace QuesAnsLib.Services.Implementations
{
    public class QuesAnsService : IQuesAnsService
    {
        private readonly IQuesAnsUnitOfWork _quesAnsUnitOfWork;

        public QuesAnsService(IQuesAnsUnitOfWork quesAnsUnitOfWork)
        {
            _quesAnsUnitOfWork = quesAnsUnitOfWork;
        }

        public void AddUser(UserBO model)
        {
            _quesAnsUnitOfWork.QuesAnsRepository.Add(new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            });
        }

        public UserBO GetUser(int Id)
        {
            var user = _quesAnsUnitOfWork.QuesAnsRepository.GetById(Id);
            return BO.UserBO.ConvertToSelf(user);

        }

        public List<User> GetUserList()
        {
            var userList = _quesAnsUnitOfWork.QuesAnsRepository.GetAll().ToList();
            return userList;
        }

        public void UpdateUser(UserBO userBO)
        {
            var userEntity = _quesAnsUnitOfWork.QuesAnsRepository.GetById(userBO.Id);

            if(userEntity != null)
            {
                userEntity.FirstName = userBO.FirstName;
                userEntity.LastName = userBO.LastName;
            }

            _quesAnsUnitOfWork.QuesAnsRepository.Update(userEntity);
        }
    }
}
