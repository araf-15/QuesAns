using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.Repositories.IRepository;
using System;
using System.Collections.Generic;

namespace QuesAnsLib.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
    }
}
