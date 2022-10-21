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
        public string Email { get; set; }


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
                LastName = user.LastName,
                UserName = user.UserName,
                InstituteName = user.InstituteName,
                InstituteId = user.InstituteId,
                UserType = user.UserType,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };
            return userBO;
        }

        public static User ConvertToEntity(UserBO userBO)
        {
            var user = new User
            {
                Id = userBO.Id,
                FirstName = userBO.FirstName,
                LastName = userBO.LastName,
                UserName = userBO.UserName,
                Email = userBO.Email,
                InstituteId = userBO.InstituteId,
                InstituteName = userBO.InstituteName,
                PasswordHash = userBO.PasswordHash,
                UserType = userBO.UserType
            };
            return user;
        }


        public void MakeHashedPassword()
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(PasswordHash);
            PasswordHash = Convert.ToBase64String(sha.ComputeHash(asByteArray)) ;
        }
    }
}
