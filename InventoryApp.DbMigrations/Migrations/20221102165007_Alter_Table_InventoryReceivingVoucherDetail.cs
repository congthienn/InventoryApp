using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryReceivingVoucherDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Materials_MaterialId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialUnit_MaterialUnitId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Users_CreatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_CreatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialUnitId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialUnitId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.AddColumn<int>(
                name: "MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventoryReceivingVoucherDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "InventoryReceivingVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialUnitId",
                table: "InventoryReceivingVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventoryReceivingVoucherDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_CreatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialUnitId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Materials_MaterialId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialUnit_MaterialUnitId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialUnitId",
                principalTable: "MaterialUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Users_CreatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
