using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaGoAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedStartedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddedIngridients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedIngridients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AddedIngridients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Халапенью", 59 },
                    { 2, "Сыр", 29 },
                    { 3, "Кетчуп", 19 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Пицца" },
                    { 2, "Десерт" },
                    { 3, "Напиток" }
                });

            migrationBuilder.InsertData(
                table: "CategorySizes",
                columns: new[] { "Id", "Capacity", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 25.0, 1, "Маленькая" },
                    { 2, 30.0, 1, "Средняя" },
                    { 3, 35.0, 1, "Большая" },
                    { 4, 0.33000000000000002, 3, "Маленький" },
                    { 5, 0.5, 3, "Средний" },
                    { 6, 1.0, 3, "Большой" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Some description of peperonni", null, "Пепперони", 200 },
                    { 2, 1, "Some description of pizza with pineaple", null, "С ананасами", 250 },
                    { 3, 1, "Some description of carbonara", null, "Карбонара", 220 },
                    { 4, 2, "Very unusual cake", null, "Шоколадный чизкейк", 50 },
                    { 5, 3, "Some Cocktail", null, "Молочный коктейль", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedIngridients");

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
