using System;

namespace QuesAnsLib.BusinessObjects
{
    public class UserBO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void ValidateUserName()
        {
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrWhiteSpace(LastName))
                throw new NotImplementedException("User Name not set properly");
        }

    }
}
