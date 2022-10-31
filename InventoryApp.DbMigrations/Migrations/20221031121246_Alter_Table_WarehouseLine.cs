using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_WarehouseLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseLine_Code",
                table: "WarehouseLine");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "WarehouseLine");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseLine",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_Code_WarehouseAreaId",
                table: "WarehouseLine",
                columns: new[] { "Code", "WarehouseAreaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_Name_WarehouseAreaId",
                table: "WarehouseLine",
                columns: new[] { "Name", "WarehouseAreaId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WarehouseLine_Code_WarehouseAreaId",
                table: "WarehouseLine");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseLine_Name_WarehouseAreaId",
                table: "WarehouseLine");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WarehouseLine",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "WarehouseLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_Code",
                table: "WarehouseLine",
                column: "Code",
                unique: true);
        }
    }
}
