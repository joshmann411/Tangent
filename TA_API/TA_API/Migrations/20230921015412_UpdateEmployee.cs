using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TA_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "BS5635");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "JD5764");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "BS7577", "0962394321", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "bayee@gmail.com", "Bandile", "Samson" },
                    { "JD5834", "0762344321", new DateTime(1996, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "John", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "BS7577");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "JD5834");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "BS5635", "0962394321", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "bayee@gmail.com", "Bandile", "Samson" },
                    { "JD5764", "0762344321", new DateTime(1996, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "John", "Doe" }
                });
        }
    }
}
