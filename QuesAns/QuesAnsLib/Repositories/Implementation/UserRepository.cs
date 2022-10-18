using NHbDataAccessLayer;
using NHbDataAccessLayer.Entities;
using QuesAnsLib.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuesAnsLib.Repositories.Implementation
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public User IsLoggedIn(string userName, string password)
        {
            var user = new User();
            using (var session = _sessionFactory.OpenSession())
            {
                user = session.Query<User>().Where(c => c.UserName == userName && c.PasswordHash == password).FirstOrDefault();
            }
            return user;
        }
    }
}
