using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerGroupId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BranchId",
                table: "Customer",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerGroupId",
                table: "Customer",
                column: "CustomerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BranchId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerGroupId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerGroupId",
                table: "Customer");
        }
    }
}
