using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.RenameColumn(
                name: "QuantityRequest",
                table: "InventoryReceivingVoucherDetail",
                newName: "ShipmentId");

            migrationBuilder.RenameColumn(
                name: "MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                newName: "DamagedQuantity");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ShipmentId1",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "InventoryReceivingVoucherDetail",
                newName: "QuantityRequest");

            migrationBuilder.RenameColumn(
                name: "DamagedQuantity",
                table: "InventoryReceivingVoucherDetail",
                newName: "MaterialShipmentId");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "InventoryReceivingVoucherDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InventoryReceivingVoucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "InventoryReceivingVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                columns: new[] { "InventoryReceivingVoucherId", "MaterialShipmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialShipmentId",
                principalTable: "MaterialShipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
