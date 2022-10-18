using NHbDataAccessLayer.Entities;
using System;
using System.Security.Cryptography;
using System.Text;

namespace QuesAnsLib.BusinessObjects
{
    public class UserBO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string PasswordHash { get; set; }
        public string InstituteName { get; set; }
        public string InstituteId { get; set; }


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

        public void MakeHashedPassword()
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(PasswordHash);
            PasswordHash = Convert.ToBase64String(sha.ComputeHash(asByteArray)) ;
        }
    }
}
