using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_InventoryReceivingVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Employees_EmployeeReceiveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Employees_EmployeeRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.RenameColumn(
                name: "EmployeeRequestId",
                table: "InventoryReceivingVoucher",
                newName: "UserRequestId");

            migrationBuilder.RenameColumn(
                name: "EmployeeReceiveId",
                table: "InventoryReceivingVoucher",
                newName: "UserReceiveId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceivingVoucher_EmployeeRequestId",
                table: "InventoryReceivingVoucher",
                newName: "IX_InventoryReceivingVoucher_UserRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceivingVoucher_EmployeeReceiveId",
                table: "InventoryReceivingVoucher",
                newName: "IX_InventoryReceivingVoucher_UserReceiveId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserApproveId",
                table: "InventoryReceivingVoucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher",
                column: "UserReceiveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReceivingVoucher_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropColumn(
                name: "UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.RenameColumn(
                name: "UserRequestId",
                table: "InventoryReceivingVoucher",
                newName: "EmployeeRequestId");

            migrationBuilder.RenameColumn(
                name: "UserReceiveId",
                table: "InventoryReceivingVoucher",
                newName: "EmployeeReceiveId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceivingVoucher_UserRequestId",
                table: "InventoryReceivingVoucher",
                newName: "IX_InventoryReceivingVoucher_EmployeeRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryReceivingVoucher_UserReceiveId",
                table: "InventoryReceivingVoucher",
                newName: "IX_InventoryReceivingVoucher_EmployeeReceiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Employees_EmployeeReceiveId",
                table: "InventoryReceivingVoucher",
                column: "EmployeeReceiveId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Employees_EmployeeRequestId",
                table: "InventoryReceivingVoucher",
                column: "EmployeeRequestId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
