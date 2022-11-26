using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class UpdateDatabasev5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                columns: new[] { "InventoryReceivingVoucherId", "ShipmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Shipment_ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Shipment_ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId");
        }
    }
}
