using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BirthDate", "JobTitle", "MobilePhone", "Name" },
                values: new object[,]
                {
                    { new Guid("2490fb81-134b-4cec-bf99-39032aa77dc5"), new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programmer", "+375298732839", "Ilya" },
                    { new Guid("42da56f3-47b2-400b-b41a-f0f048ecbe58"), new DateTime(1982, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programmer", "+375291234569", "Luke" },
                    { new Guid("77cd0cec-b448-45c1-a805-07f9ed5297da"), new DateTime(1993, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", "+375331238669", "Madeleine" },
                    { new Guid("b8c52266-5927-493e-8630-bdf10e54240d"), new DateTime(2000, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loader", "+375441254889", "Oswald" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MobilePhone",
                table: "Contacts",
                column: "MobilePhone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
