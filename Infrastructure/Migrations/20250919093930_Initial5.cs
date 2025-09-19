using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "item_type",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "found_item_status",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "item_type",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "item_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "found_item_status",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "item_type",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
