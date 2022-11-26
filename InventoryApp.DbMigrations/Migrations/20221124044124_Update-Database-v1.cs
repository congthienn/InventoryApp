using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class UpdateDatabasev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucher_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucher_UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucher_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucher_UserRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropColumn(
                name: "UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropColumn(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "UserRequestId",
                table: "InventoryDeliveryVoucher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryReceivingVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserRequestId",
                table: "InventoryReceivingVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRequestId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_UserRequestId",
                table: "InventoryReceivingVoucher",
                column: "UserRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_UserRequestId",
                table: "InventoryDeliveryVoucher",
                column: "UserRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
