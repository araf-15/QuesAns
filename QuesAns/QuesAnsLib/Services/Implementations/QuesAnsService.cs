using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<object> AddUser(UserBO model)
        {
            return await _quesAnsUnitOfWork.QuesAnsRepository.Add(new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                UserType = model.UserType,
                PasswordHash = model.PasswordHash,
                InstituteName = model.InstituteName,
                InstituteId = model.InstituteId

            });
        }

        public UserBO GetUser(Guid Id)
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

        public void DeleteUser(Guid id)
        {
            var userEntity = _quesAnsUnitOfWork.QuesAnsRepository.GetById(id);

            _quesAnsUnitOfWork.QuesAnsRepository.Delete(userEntity);
        }

        public UserBO IsLoggedIn(string userName, string password)
        {
            var user = _quesAnsUnitOfWork.QuesAnsRepository.IsLoggedIn(userName, password);
            if(user != null)
            {
                return BO.UserBO.ConvertToSelf(user);
            }
            return null;
        }
    }
}
