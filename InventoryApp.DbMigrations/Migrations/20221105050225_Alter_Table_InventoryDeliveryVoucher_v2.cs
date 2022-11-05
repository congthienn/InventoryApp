using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucher_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "InventoryDeliveryVoucher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_OrderId",
                table: "InventoryDeliveryVoucher",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Order_OrderId",
                table: "InventoryDeliveryVoucher",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Order_OrderId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucher_OrderId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "InventoryDeliveryVoucher");
        }
    }
}
