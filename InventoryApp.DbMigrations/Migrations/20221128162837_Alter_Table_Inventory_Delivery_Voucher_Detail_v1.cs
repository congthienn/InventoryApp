using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Inventory_Delivery_Voucher_Detail_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialsId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialsId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "MaterialsId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialsId",
                table: "InventoryDeliveryVoucherDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialsId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialsId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
