using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodMenu.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodMenuIngridients",
                columns: table => new
                {
                    IngridientId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenuIngridients", x => new { x.IngridientId, x.FoodId });
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FoodMenuIngridientFoodId = table.Column<int>(type: "int", nullable: true),
                    FoodMenuIngridientIngridientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodMenuIngridients_FoodMenuIngridientIngridientId_FoodMenuIngridientFoodId",
                        columns: x => new { x.FoodMenuIngridientIngridientId, x.FoodMenuIngridientFoodId },
                        principalTable: "FoodMenuIngridients",
                        principalColumns: new[] { "IngridientId", "FoodId" });
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodMenuIngridientFoodId = table.Column<int>(type: "int", nullable: true),
                    FoodMenuIngridientIngridientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingridients_FoodMenuIngridients_FoodMenuIngridientIngridientId_FoodMenuIngridientFoodId",
                        columns: x => new { x.FoodMenuIngridientIngridientId, x.FoodMenuIngridientFoodId },
                        principalTable: "FoodMenuIngridients",
                        principalColumns: new[] { "IngridientId", "FoodId" });
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "FoodMenuIngridientFoodId", "FoodMenuIngridientIngridientId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, null, null, "", "Margaritta", 23.5 });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "FoodMenuIngridientFoodId", "FoodMenuIngridientIngridientId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Sauce" },
                    { 2, null, null, "Cheese" }
                });

            migrationBuilder.InsertData(
                table: "FoodMenuIngridients",
                columns: new[] { "FoodId", "IngridientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuIngridients_FoodId",
                table: "FoodMenuIngridients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodMenuIngridientIngridientId_FoodMenuIngridientFoodId",
                table: "Foods",
                columns: new[] { "FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_FoodMenuIngridientIngridientId_FoodMenuIngridientFoodId",
                table: "Ingridients",
                columns: new[] { "FoodMenuIngridientIngridientId", "FoodMenuIngridientFoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenuIngridients_Foods_FoodId",
                table: "FoodMenuIngridients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMenuIngridients_Ingridients_IngridientId",
                table: "FoodMenuIngridients",
                column: "IngridientId",
                principalTable: "Ingridients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenuIngridients_Foods_FoodId",
                table: "FoodMenuIngridients");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMenuIngridients_Ingridients_IngridientId",
                table: "FoodMenuIngridients");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "FoodMenuIngridients");
        }
    }
}
