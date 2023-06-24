using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaGoAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "CategoryId", "Name" },
                values: new object[] { 100.0, 2, "Маленький кусочек" });

            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacity", "CategoryId", "Name" },
                values: new object[] { 250.0, 2, "Большой кусочек" });

            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacity", "Name" },
                values: new object[] { 0.33000000000000002, "Маленький" });

            migrationBuilder.InsertData(
                table: "CategorySizes",
                columns: new[] { "Id", "Capacity", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 7, 0.5, 3, "Средний" },
                    { 8, 1.0, 3, "Большой" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "CategoryId", "Name" },
                values: new object[] { 0.33000000000000002, 3, "Маленький" });

            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Capacity", "CategoryId", "Name" },
                values: new object[] { 0.5, 3, "Средний" });

            migrationBuilder.UpdateData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Capacity", "Name" },
                values: new object[] { 1.0, "Большой" });
        }
    }
}
