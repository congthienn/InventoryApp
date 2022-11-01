using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_WarehouseShelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseShelves_Code",
                table: "WarehouseShelves");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "WarehouseShelves");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseShelves",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_Code_WarehouseLineId",
                table: "WarehouseShelves",
                columns: new[] { "Code", "WarehouseLineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_Name_WarehouseLineId",
                table: "WarehouseShelves",
                columns: new[] { "Name", "WarehouseLineId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseShelves_Code_WarehouseLineId",
                table: "WarehouseShelves");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseShelves_Name_WarehouseLineId",
                table: "WarehouseShelves");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseShelves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "WarehouseShelves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_Code",
                table: "WarehouseShelves",
                column: "Code",
                unique: true);
        }
    }
}
