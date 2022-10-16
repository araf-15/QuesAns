using Membership.Context.DataSeed;
using Membership.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Membership.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid, UserClaim,
        UserRole, UserLogin, RoleClaim, UserToken>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData.MakeDataSeed(builder);

            base.OnModelCreating(builder);
        }






    }
}
