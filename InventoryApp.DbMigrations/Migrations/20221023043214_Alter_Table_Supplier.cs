using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppelationOfForeignTrader",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ForeignName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Supplier",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierGroupId",
                table: "Supplier",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierGroupId",
                table: "Supplier",
                column: "SupplierGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier",
                column: "SupplierGroupId",
                principalTable: "SupplierGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupplierGroupId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierGroupId",
                table: "Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppelationOfForeignTrader",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignName",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
