using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public UserRole() : base() { }
    }
}
