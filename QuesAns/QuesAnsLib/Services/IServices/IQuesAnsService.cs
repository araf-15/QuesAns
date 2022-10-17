using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Services.IServices
{
    public interface IQuesAnsService
    {
        List<User> GetUserList();
        void AddUser(UserBO model);

        UserBO GetUser(int Id);
    }
}
