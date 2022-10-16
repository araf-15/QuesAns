using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Entities
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public RoleClaim() : base() { }
    }
}
