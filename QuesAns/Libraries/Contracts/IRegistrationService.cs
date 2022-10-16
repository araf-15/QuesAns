using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRegistrationService
    {
        public void RegisterUser(string userName, string contractNo);
    }
}
