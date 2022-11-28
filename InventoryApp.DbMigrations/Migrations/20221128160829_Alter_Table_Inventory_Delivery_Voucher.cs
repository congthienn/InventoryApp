using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Inventory_Delivery_Voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityRequest",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.AddColumn<Guid>(
                name: "UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                column: "UserDeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                column: "UserDeliveryId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserDeliveryId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucher_UserDeliveryId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "UserDeliveryId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.AddColumn<int>(
                name: "QuantityRequest",
                table: "InventoryDeliveryVoucherDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InventoryDeliveryVoucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Purpose",
                table: "InventoryDeliveryVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InventoryDeliveryVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
