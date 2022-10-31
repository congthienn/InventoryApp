using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_WarehouseArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseArea_Code",
                table: "WarehouseArea");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "WarehouseArea");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseArea",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseArea_Code_WarehouseId",
                table: "WarehouseArea",
                columns: new[] { "Code", "WarehouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseArea_Name_WarehouseId",
                table: "WarehouseArea",
                columns: new[] { "Name", "WarehouseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseArea_Code_WarehouseId",
                table: "WarehouseArea");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseArea_Name_WarehouseId",
                table: "WarehouseArea");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseArea",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "WarehouseArea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseArea_Code",
                table: "WarehouseArea",
                column: "Code",
                unique: true);
        }
    }
}
