using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Materials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Materials",
                newName: "Weight");

            migrationBuilder.AddColumn<int>(
                name: "CostPrice",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalePrice",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Materials",
                newName: "Details");
        }
    }
}
