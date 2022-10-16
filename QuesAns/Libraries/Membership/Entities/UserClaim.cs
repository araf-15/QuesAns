using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Entities
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public UserClaim() : base() { }
    }
}
