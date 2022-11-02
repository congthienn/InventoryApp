using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucherDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_MaterialUnit_MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.RenameColumn(
                name: "UpdatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                newName: "ShipmentId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "InventoryDeliveryVoucherDetail",
                newName: "MaterialPrice");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucherDetail_UpdatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                newName: "IX_InventoryDeliveryVoucherDetail_ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucherId_ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                columns: new[] { "InventoryDeliveryVoucherId", "ShipmentId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucherId_ShipmentId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                newName: "UpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "MaterialPrice",
                table: "InventoryDeliveryVoucherDetail",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucherDetail_ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                newName: "IX_InventoryDeliveryVoucherDetail_UpdatedByUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventoryDeliveryVoucherDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventoryDeliveryVoucherDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail",
                column: "InventoryDeliveryVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_MaterialUnit_MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialUnitId",
                principalTable: "MaterialUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
