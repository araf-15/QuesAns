using Autofac;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuesAns.Utility;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.Implementations;
using QuesAnsLib.Services.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.Models.AccountModels
{
    public class UserVM
    {
        #region Propertise

        public Guid Id { get; set; }
        [Required(ErrorMessage="Please provide your First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide your User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please provide User Type")]
        public string UserType { get; set; }
        [Required(ErrorMessage = "Please provide Password")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Please provide your Institute Name")]
        public string InstituteName { get; set; }
        [Required(ErrorMessage = "Please provide your Institute Id")]
        public string InstituteId { get; set; }
        [Required(ErrorMessage = "Please provide Email Address")]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> UserTypeLookup { get; set; }

        #endregion

        #region Config

        private readonly IQuesAnsService _quesAnsService;
        private readonly ICashService<string, UserVM> _iCashService;
        private readonly ApplicationService _applicationService;
        public UserVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
            _iCashService = Startup.AutofacContainer.Resolve<ICashService<string, UserVM>>();
            _applicationService = Startup.AutofacContainer.Resolve<ApplicationService>();
        }

        #endregion


        #region Methods
        public async Task<object> RegisterUser()
        {
            var userBO = ConvertToBOUser();
            return await _quesAnsService.AddUser(userBO);
        }

        public void GetLoginUser()
        {
            var userBO = _quesAnsService.IsLoggedIn(Email, _applicationService.HasedPassword(PasswordHash));
            if (userBO != null)
            {
                Id = userBO.Id;
                FirstName = userBO.FirstName;
                LastName = userBO.LastName;
                UserName = userBO.UserName;
                UserType = userBO.UserType;
                PasswordHash = userBO.PasswordHash;
                InstituteName = userBO.InstituteName;
                InstituteId = userBO.InstituteId;
                Email = userBO.Email;
            }
        }

        #endregion

        #region CashMemory Methods

        public UserVM GetUserCashData(string userName)
        {
            var cashData = _iCashService.GetCashedData(userName);
            return cashData;
        }

        public void AddUserCashedData(string key, UserVM modelValue)
        {
            _iCashService.Add(key, modelValue);
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
                InstituteId = InstituteId,
                Email = Email
            };
            userBo.MakeHashedPassword();
            return userBo;
        }

        public string HashUserPassword(string plainText)
        {
            return _applicationService.HasedPassword(plainText);
        }
        #endregion
    }
}
