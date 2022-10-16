using Autofac;
using QuesAnsLib.Services.IServices;
using System;

namespace QuesAns.Areas.Admin.Models
{
    public class UserVM
    {
        public Guid Id { get; set; }
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


        public void GetUserList()
        {
            var userList = _quesAnsService.GetUserList();
        }
    }
}
