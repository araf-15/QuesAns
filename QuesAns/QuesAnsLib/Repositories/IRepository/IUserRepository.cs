using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace QuesAnsLib.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        
    }
}
