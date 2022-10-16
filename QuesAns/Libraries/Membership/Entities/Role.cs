﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role() : base(){ }
        public Role(string roleName) : base(roleName) { }
    }
}
