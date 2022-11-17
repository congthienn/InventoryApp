using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Shipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_BranchId",
                table: "Shipment",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_BranchId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Shipment");
        }
    }
}
