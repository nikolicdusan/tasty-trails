using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryChannel.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMenuReferenceFromItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MenuId",
                table: "Items",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
