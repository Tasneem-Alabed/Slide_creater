using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slid_App.Migrations
{
    /// <inheritdoc />
    public partial class UserMg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBerth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slids",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlidId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SlidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlidUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slids", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Slids_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UFiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UFiles_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlidId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Slids_SlidId",
                        column: x => x.SlidId,
                        principalTable: "Slids",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Slids",
                columns: new[] { "UserId", "SlidId", "SlidName", "SlidUrl", "UserId1" },
                values: new object[] { 1, 1, "Sample Slid", "/slides/1/Slid", null });

            migrationBuilder.InsertData(
                table: "UFiles",
                columns: new[] { "UserId", "Id", "ImageUrl", "Name", "UserId1", "VideoUrl" },
                values: new object[] { 1, 1, "https://example.com/sample.jpg", "Sample File", null, "https://example.com/sample.mp4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBerth", "Email", "EmailConfirmed", "ImageBase64", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "554c2a49-9253-4c4c-9e8a-23b42876dc8d", 0, "354d8f0d-9dbb-4953-9dd2-04701687b743", "1990-01-01", "john.doe@example.com", false, "base64encodedimage", false, null, "John Doe", null, null, "password123", null, "123-456-7890", false, "f96e2d72-6110-4c6d-b8ca-d79f9b96e68c", false, 1, null });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "ImageBase64", "SlidId", "Text", "VideoUrl" },
                values: new object[] { 1, null, 1, "Page Content", null });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_SlidId",
                table: "Pages",
                column: "SlidId");

            migrationBuilder.CreateIndex(
                name: "IX_Slids_UserId1",
                table: "Slids",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UFiles_UserId1",
                table: "UFiles",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "UFiles");

            migrationBuilder.DropTable(
                name: "Slids");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
