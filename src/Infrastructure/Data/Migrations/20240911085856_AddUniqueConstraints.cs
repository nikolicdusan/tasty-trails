using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Name_City_Address",
                table: "Restaurants",
                columns: new[] { "Name", "City", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId_Name",
                table: "Menus",
                columns: new[] { "RestaurantId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId_Name",
                table: "MenuItems",
                columns: new[] { "MenuId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurants_Name_City_Address",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Menus_RestaurantId_Name",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuId_Name",
                table: "MenuItems");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");
        }
    }
}
