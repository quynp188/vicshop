using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VicShop.Migrations
{
    public partial class changeIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b23bbb5-f42b-41e1-ada3-8238d3d3c636", "d0256af2-7fff-42b6-97fc-731f921e18d4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b23bbb5-f42b-41e1-ada3-8238d3d3c636");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0256af2-7fff-42b6-97fc-731f921e18d4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "5b23bbb5-f42b-41e1-ada3-8238d3d3c636", "b3a06210-2e56-44cd-b320-2c69ac05d732", "Super Admin", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "DepartmentId", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d0256af2-7fff-42b6-97fc-731f921e18d4", 0, "Mỹ Đình 2- Nam Từ Liêm - Hà Nội", null, null, "6fecc872-3103-4224-ae90-ba86615dea1d", null, null, "769939f6-e05c-42dc-8368-718efa770da5", "phuquyfrec@gmail.com", false, "Nguyễn Phú Quý", 0, false, null, null, "MYUSER", "AQAAAAEAACcQAAAAEF5VmKn8P2U27gi23PxJmzEXFamPX15TxFipimM5/hW9OBDAsKHnrjBx0XlRZFcAAg==", "0349626569", false, null, false, "qunp" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b23bbb5-f42b-41e1-ada3-8238d3d3c636", "d0256af2-7fff-42b6-97fc-731f921e18d4" });
        }
    }
}
