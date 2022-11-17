using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_MaterialUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialUnit_MaterialUnitId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialUnitId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "MaterialUnitId",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "DirectSales",
                table: "MaterialUnit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ExchangeValue",
                table: "MaterialUnit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "MaterialUnit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "MaterialUnit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BaseMaterialUnit",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUnit_MaterialId",
                table: "MaterialUnit",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit");

            migrationBuilder.DropIndex(
                name: "IX_MaterialUnit_MaterialId",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "DirectSales",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "ExchangeValue",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MaterialUnit");

            migrationBuilder.DropColumn(
                name: "BaseMaterialUnit",
                table: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MaterialUnit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "MaterialUnit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialUnitId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialUnitId",
                table: "Materials",
                column: "MaterialUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialUnit_MaterialUnitId",
                table: "Materials",
                column: "MaterialUnitId",
                principalTable: "MaterialUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
