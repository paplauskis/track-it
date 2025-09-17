using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_item_type_ItemTypeId",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "item",
                newName: "ItemTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_item_ItemTypeId",
                table: "item",
                newName: "IX_item_ItemTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_item_item_type_ItemTypeId1",
                table: "item",
                column: "ItemTypeId1",
                principalTable: "item_type",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_item_type_ItemTypeId1",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId1",
                table: "item",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_item_ItemTypeId1",
                table: "item",
                newName: "IX_item_ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_item_item_type_ItemTypeId",
                table: "item",
                column: "ItemTypeId",
                principalTable: "item_type",
                principalColumn: "id");
        }
    }
}
