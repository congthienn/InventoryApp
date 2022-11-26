using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class UpdateDatabasev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_Branches_BranchId",
                table: "MaterialPosition");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPosition_BranchId",
                table: "MaterialPosition");

            migrationBuilder.DropColumn(
                name: "BrachId",
                table: "MaterialPosition");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "MaterialPosition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrachId",
                table: "MaterialPosition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "MaterialPosition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPosition_BranchId",
                table: "MaterialPosition",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_Branches_BranchId",
                table: "MaterialPosition",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
