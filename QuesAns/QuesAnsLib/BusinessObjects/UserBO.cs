using NHbDataAccessLayer.Entities;
using System;

namespace QuesAnsLib.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void ValidateUserName()
        {
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrWhiteSpace(LastName))
                throw new NotImplementedException("User Name not set properly");
        }

        public static UserBO ConvertToSelf(User user)
        {
            var userBO = new UserBO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userBO;
        }

    }
}
