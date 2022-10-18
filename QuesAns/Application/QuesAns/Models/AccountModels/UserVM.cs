using Autofac;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Models.AccountModels
{
    public class UserVM
    {
        #region Propertise

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string PasswordHash { get; set; }
        public string InstituteName { get; set; }
        public string InstituteId { get; set; }

        #endregion

        #region Config

        private readonly IQuesAnsService _quesAnsService;
        public UserVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
        }

        #endregion


        #region Methods
        public async Task<object> RegisterUser()
        {
            var userBO = ConvertToBOUser();
            return await _quesAnsService.AddUser(userBO);
        }
        #endregion



        #region HelperMethods
        private UserBO ConvertToBOUser()
        {
            var userBo = new UserBO
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                UserType = UserType,
                PasswordHash = PasswordHash,
                InstituteName = InstituteName,
                InstituteId = InstituteId
            };
            userBo.MakeHashedPassword();
            return userBo;
        }
        #endregion
    }
}
