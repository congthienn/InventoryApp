using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryDeliveryVoucher_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryDeliveryVoucher_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryDeliveryVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDeliveryVoucher_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Customer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Customer_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                        column: x => x.InventoryDeliveryVoucherId,
                        principalTable: "InventoryDeliveryVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_Customer_CustomerId_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucher_Customer",
                columns: new[] { "CustomerId", "InventoryDeliveryVoucherId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_Customer_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucher_Customer",
                column: "InventoryDeliveryVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDeliveryVoucher_Customer");
        }
    }
}
