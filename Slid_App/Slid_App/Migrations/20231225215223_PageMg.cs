using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slid_App.Migrations
{
    /// <inheritdoc />
    public partial class PageMg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "df46f66f-f8be-446d-be3c-90dbfc22ad31");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "2ef4b14a-ac46-4b14-93a5-0f54822e8f10", 0, "e6ff1c6a-5cbd-48a0-8ca9-8076be31f1c0", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "a3a30277-b521-430b-894b-d967dc37d56c", false, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2ef4b14a-ac46-4b14-93a5-0f54822e8f10");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "df46f66f-f8be-446d-be3c-90dbfc22ad31", 0, "c50425cd-8c3f-4c4c-aab6-7eda627f788c", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "c84cb4f2-19ae-4bfd-9f18-7f0aaa572fab", false, 1, null });
        }
    }
}
