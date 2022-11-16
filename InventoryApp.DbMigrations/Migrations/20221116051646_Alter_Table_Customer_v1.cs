using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Customer_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaxCode",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Fax",
                table: "Customer",
                column: "Fax",
                unique: true,
                filter: "[Fax] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TaxCode",
                table: "Customer",
                column: "TaxCode",
                unique: true,
                filter: "[TaxCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Fax",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_TaxCode",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "TaxCode",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
