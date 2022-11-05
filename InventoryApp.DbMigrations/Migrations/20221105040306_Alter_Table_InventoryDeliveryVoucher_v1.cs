using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucher_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "InventoryDeliveryVoucher",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Purpose",
                table: "InventoryDeliveryVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "InventoryDeliveryVoucher",
                newName: "StatusId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
