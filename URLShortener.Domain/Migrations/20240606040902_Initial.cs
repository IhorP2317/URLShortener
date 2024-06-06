using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortenUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shorten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutMessages",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Message" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The URL shortening service utilizes a mathematical concept known as a bijective function. A bijective function, or bijection, is a one-to-one correspondence between two sets, meaning each element in one set maps to exactly one unique element in the other set, and vice versa. This property ensures that each long URL maps to a unique short URL, and each short URL maps back to its original long URL without any collisions.\n\nBy applying a bijective function to generate short URLs, we ensure that our shortened URLs are unique and reversible. This means that given a short URL, we can always retrieve the original long URL it represents.\n\nIf you want to learn more about bijective functions, please visit the <a href='https://en.wikipedia.org/wiki/Bijection'>Wikipedia page on Bijection</a>." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "Password", "Role" },
                values: new object[] { 1, null, new DateTime(2024, 6, 6, 7, 9, 1, 832, DateTimeKind.Local).AddTicks(2400), "admin@gmail.com", "Admin1234", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutMessages");

            migrationBuilder.DropTable(
                name: "ShortenUrls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
