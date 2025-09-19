using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "item_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "found_item_status",
                newName: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "item_type",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "found_item_status",
                newName: "Name");
        }
    }
}
