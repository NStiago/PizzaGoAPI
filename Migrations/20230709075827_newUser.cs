using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGoAPI.Migrations
{
    /// <inheritdoc />
    public partial class newUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Login", "Name", "Password", "Phone", "Surname" },
                values: new object[] { new Guid("ca761232-ed42-11ce-bacd-00aa0057b223"), "skdmitriev70@gmail.com", true, "semenitago", "Sementiago", "123456", "8-913-000-00-00", "Dmitriev" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca761232-ed42-11ce-bacd-00aa0057b223"));
        }
    }
}
