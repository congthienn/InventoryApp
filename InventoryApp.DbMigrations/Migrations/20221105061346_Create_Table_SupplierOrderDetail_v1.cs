using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_SupplierOrderDetail_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierOrderId",
                table: "InventoryReceivingVoucher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_SupplierOrderId",
                table: "InventoryReceivingVoucher",
                column: "SupplierOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_SupplierOrder_SupplierOrderId",
                table: "InventoryReceivingVoucher",
                column: "SupplierOrderId",
                principalTable: "SupplierOrder",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_SupplierOrder_SupplierOrderId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucher_SupplierOrderId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropColumn(
                name: "SupplierOrderId",
                table: "InventoryReceivingVoucher");
        }
    }
}
