using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryChannel.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Items_ItemId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Menus_MenuId",
                table: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_ItemId",
                table: "MenuItems",
                newName: "IX_MenuItems_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                columns: new[] { "MenuId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Items_ItemId",
                table: "MenuItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Items_ItemId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "MenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_ItemId",
                table: "MenuItem",
                newName: "IX_MenuItem_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                columns: new[] { "MenuId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Items_ItemId",
                table: "MenuItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Menus_MenuId",
                table: "MenuItem",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
