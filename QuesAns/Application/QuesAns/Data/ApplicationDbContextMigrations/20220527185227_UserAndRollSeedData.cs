using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuesAns.Data.ApplicationDbContextMigrations
{
    public partial class UserAndRollSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cbce028c-0bcd-48df-86e3-910192963c7b"), "eae6204d-9065-48da-8d13-1ce7be589d36", "Admin", "ADMIN" },
                    { new Guid("fc13954f-7e64-41ce-a48d-875350a8dd60"), "e574fb0e-9725-40c0-9af9-d7c185634c46", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("e20a7050-86f1-4b6a-93a9-c2d3a9d114ea"), "e0f91495-19d8-49b3-9a43-a0cba8a72528", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("fef9f731-4e82-45b4-8bb6-9d6ca9d80ab7"), 0, "0d24ff68-dae0-4a7f-9c32-cd9c42977099", "superadmin@gmail.com", false, "MD. ARAF HASAN", null, true, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAHtZV0/j0p94/VqFGEAppKw5MmbrVyvv0tORIvIjvCOzV3apYDS51+1VZlDwv1JQA==", null, false, "GBET7DFCHRRR3NK3WZF43FH2L6EPWQW2", false, "superadmin@gmail.com" },
                    { new Guid("30da08be-c7b0-4db1-8f67-fe8bdd282469"), 0, "0d24ff68-dae0-4a7f-9c32-cd9c42977099", "admin@gmail.com", false, "MD. ARAF HASAN", null, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAHtZV0/j0p94/VqFGEAppKw5MmbrVyvv0tORIvIjvCOzV3apYDS51+1VZlDwv1JQA==", null, false, "GBET7DFCHRRR3NK3WZF43FH2L6EPWQW2", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("30da08be-c7b0-4db1-8f67-fe8bdd282469"), new Guid("cbce028c-0bcd-48df-86e3-910192963c7b") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("fef9f731-4e82-45b4-8bb6-9d6ca9d80ab7"), new Guid("fc13954f-7e64-41ce-a48d-875350a8dd60") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e20a7050-86f1-4b6a-93a9-c2d3a9d114ea"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("30da08be-c7b0-4db1-8f67-fe8bdd282469"), new Guid("cbce028c-0bcd-48df-86e3-910192963c7b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("fef9f731-4e82-45b4-8bb6-9d6ca9d80ab7"), new Guid("fc13954f-7e64-41ce-a48d-875350a8dd60") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbce028c-0bcd-48df-86e3-910192963c7b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc13954f-7e64-41ce-a48d-875350a8dd60"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30da08be-c7b0-4db1-8f67-fe8bdd282469"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fef9f731-4e82-45b4-8bb6-9d6ca9d80ab7"));
        }
    }
}
