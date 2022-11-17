using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryDeliveryVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Employees_EmployeeDeliveryId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Employees_EmployeeRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "EmployeeRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "UserRequestId");

            migrationBuilder.RenameColumn(
                name: "EmployeeDeliveryId",
                table: "InventoryDeliveryVoucher",
                newName: "UserDeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_EmployeeRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_UserRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_EmployeeDeliveryId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_UserDeliveryId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                column: "UserDeliveryId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserDeliveryId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDeliveryVoucher_UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "UserApproveId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "UserRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "EmployeeRequestId");

            migrationBuilder.RenameColumn(
                name: "UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                newName: "EmployeeDeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_UserRequestId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_EmployeeRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDeliveryVoucher_UserDeliveryId",
                table: "InventoryDeliveryVoucher",
                newName: "IX_InventoryDeliveryVoucher_EmployeeDeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Employees_EmployeeDeliveryId",
                table: "InventoryDeliveryVoucher",
                column: "EmployeeDeliveryId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Employees_EmployeeRequestId",
                table: "InventoryDeliveryVoucher",
                column: "EmployeeRequestId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
