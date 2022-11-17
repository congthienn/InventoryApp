using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucher_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "BranchRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_BranchRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_BranchId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "InventoryDeliveryVoucher",
                newName: "BranchRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_BranchId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_BranchRequestId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchRequestId",
                table: "InventoryDeliveryVoucher",
                column: "BranchRequestId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
