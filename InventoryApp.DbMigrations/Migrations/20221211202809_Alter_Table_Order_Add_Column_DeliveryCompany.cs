using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_Order_Add_Column_DeliveryCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryCompanyId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryCompanyId",
                table: "Order",
                column: "DeliveryCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryCompany_DeliveryCompanyId",
                table: "Order",
                column: "DeliveryCompanyId",
                principalTable: "DeliveryCompany",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryCompany_DeliveryCompanyId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DeliveryCompanyId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyId",
                table: "Order");
        }
    }
}
