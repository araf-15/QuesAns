using Autofac;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using System;

namespace QuesAns.Areas.Admin.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region Configure
        private readonly IQuesAnsService _quesAnsService;

        public UserVM()
        {
            _quesAnsService = Startup.AutofacContainer.Resolve<IQuesAnsService>();
            //_quesAnsService = quesAnsService;
        }

        #endregion

        public void AddUser()
        {
            var userBO = new UserBO
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName
            };
            _quesAnsService.AddUser(userBO);
        }

        public void LoadtUser()
        {
            var model = _quesAnsService.GetUser(Id);
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
        }

        public void UpdateUser()
        {
            var userBO = ConvertToBOUser();
            _quesAnsService.UpdateUser(userBO);
        }

        public void DeleteUser()
        {
            _quesAnsService.DeleteUser(Id);
        }


        public void GetUserList()
        {
            var userList = _quesAnsService.GetUserList();
        }

        public UserBO ConvertToBOUser()
        {
            var userBO = new UserBO
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName
            };
            return userBO;
        }

        
    }
}
