using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slid_App.Migrations
{
    /// <inheritdoc />
    public partial class YourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "88cc724a-7c22-49f1-863e-dcaeb1cba976");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "9a143767-cb65-40b2-9154-36f35d971119", 0, "6848ffa1-cdc5-4f2f-85dc-74990f2b3245", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "5b9d8383-b4dc-44d7-9992-1220e7db6961", false, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9a143767-cb65-40b2-9154-36f35d971119");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "88cc724a-7c22-49f1-863e-dcaeb1cba976", 0, "d91f4d74-1185-4093-bd02-b614f3b81957", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "4c0c469e-dd8b-4a79-ae6a-0a944b4d03db", false, 1, null });
        }
    }
}
