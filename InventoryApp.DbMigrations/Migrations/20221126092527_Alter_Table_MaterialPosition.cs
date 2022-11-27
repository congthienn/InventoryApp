using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_MaterialPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "MaterialPosition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPosition_ShipmentId",
                table: "MaterialPosition",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_Shipment_ShipmentId",
                table: "MaterialPosition",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_Shipment_ShipmentId",
                table: "MaterialPosition");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPosition_ShipmentId",
                table: "MaterialPosition");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "MaterialPosition");
        }
    }
}
