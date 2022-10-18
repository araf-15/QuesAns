using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using System;
using System.Collections.Generic;
using BO = QuesAnsLib.BusinessObjects;
using System.Text;
using System.Threading.Tasks;

namespace QuesAnsLib.Services.IServices
{
    public interface IQuesAnsService
    {
        List<User> GetUserList();
        Task<object> AddUser(UserBO model);

        UserBO GetUser(Guid Id);
        void UpdateUser(BO.UserBO userBO);
        void DeleteUser(Guid id);
        UserBO IsLoggedIn(string userName, string password);
    }
}
