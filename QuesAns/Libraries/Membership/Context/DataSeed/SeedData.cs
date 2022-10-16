using Membership.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Context.DataSeed
{
    public static class SeedData
    {
        private static List<ApplicationUser> ApplicationUsers = new List<ApplicationUser>();
        private static List<Role> Roles = new List<Role>();

        public static void MakeDataSeed(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(GetSeedingRoles());
            builder.Entity<ApplicationUser>().HasData(GetSeedingUsers());
            builder.Entity<UserRole>().HasData(GetSeedingUserRoles());
        }


        private static List<UserRole> GetSeedingUserRoles()
        {
            var userRolls = new List<UserRole>();
            userRolls.Add(new UserRole { UserId = ApplicationUsers.FirstOrDefault(c => c.UserName == "admin@gmail.com").Id, RoleId = Roles.FirstOrDefault(c => c.Name == "Admin").Id });
            userRolls.Add(new UserRole { UserId = ApplicationUsers.FirstOrDefault(c => c.UserName == "superadmin@gmail.com").Id, RoleId = Roles.FirstOrDefault(c => c.Name == "SuperAdmin").Id });
            return userRolls;
        }


        private static List<Role> GetSeedingRoles()
        {
            Roles.Add(new Role { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" });
            Roles.Add(new Role { Id = Guid.NewGuid(), Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            Roles.Add(new Role { Id = Guid.NewGuid(), Name = "Customer", NormalizedName = "CUSTOMER" });
            return Roles;
        }

        private static List<ApplicationUser> GetSeedingUsers()
        {
            ApplicationUsers.Add(
                    new ApplicationUser
                    {
                        Id = Guid.NewGuid(),
                        UserName = "superadmin@gmail.com",
                        NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                        Email = "superadmin@gmail.com",
                        NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEAHtZV0/j0p94/VqFGEAppKw5MmbrVyvv0tORIvIjvCOzV3apYDS51+1VZlDwv1JQA==", // password: araf.hasan
                        SecurityStamp = "GBET7DFCHRRR3NK3WZF43FH2L6EPWQW2",
                        ConcurrencyStamp = "0d24ff68-dae0-4a7f-9c32-cd9c42977099",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        ImageUrl = null,
                        FullName = "MD. ARAF HASAN"
                    }
                );

            ApplicationUsers.Add(
                    new ApplicationUser
                    {
                        Id = Guid.NewGuid(),
                        UserName = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEAHtZV0/j0p94/VqFGEAppKw5MmbrVyvv0tORIvIjvCOzV3apYDS51+1VZlDwv1JQA==", // password: araf.hasan
                        SecurityStamp = "GBET7DFCHRRR3NK3WZF43FH2L6EPWQW2",
                        ConcurrencyStamp = "0d24ff68-dae0-4a7f-9c32-cd9c42977099",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        ImageUrl = null,
                        FullName = "MD. ARAF HASAN"
                    }
                );
            return ApplicationUsers;
        }


    }
}
