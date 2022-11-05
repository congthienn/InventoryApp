using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucherDetail_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialPrice",
                table: "InventoryDeliveryVoucherDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "InventoryDeliveryVoucherDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaterialPrice",
                table: "InventoryDeliveryVoucherDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
