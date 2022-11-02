using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryReceivingVoucherDetail_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                columns: new[] { "InventoryReceivingVoucherId", "MaterialShipmentId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId");
        }
    }
}
