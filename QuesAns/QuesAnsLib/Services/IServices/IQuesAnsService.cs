using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Services.IServices
{
    public interface IQuesAnsService
    {
        List<User> GetUserList();
    }
}
