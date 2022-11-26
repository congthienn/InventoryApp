using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class UpdateDatabasev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Shipment_ShipmentId1",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_ShipmentId1",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "ShipmentId1",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId1",
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
                name: "IX_InventoryReceivingVoucherDetail_ShipmentId1",
                table: "InventoryReceivingVoucherDetail",
                column: "ShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Shipment_ShipmentId1",
                table: "InventoryReceivingVoucherDetail",
                column: "ShipmentId1",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
