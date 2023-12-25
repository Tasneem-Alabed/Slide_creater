using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slid_App.Migrations
{
    /// <inheritdoc />
    public partial class UFileMg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2ef4b14a-ac46-4b14-93a5-0f54822e8f10");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "88cc724a-7c22-49f1-863e-dcaeb1cba976", 0, "d91f4d74-1185-4093-bd02-b614f3b81957", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "4c0c469e-dd8b-4a79-ae6a-0a944b4d03db", false, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "88cc724a-7c22-49f1-863e-dcaeb1cba976");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "2ef4b14a-ac46-4b14-93a5-0f54822e8f10", 0, "e6ff1c6a-5cbd-48a0-8ca9-8076be31f1c0", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "a3a30277-b521-430b-894b-d967dc37d56c", false, 1, null });
        }
    }
}
