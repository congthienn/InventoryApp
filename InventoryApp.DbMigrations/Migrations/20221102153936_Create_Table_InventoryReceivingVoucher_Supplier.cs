using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryReceivingVoucher_Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryReceivingVoucher_Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryReceivingVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceivingVoucher_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                        column: x => x.InventoryReceivingVoucherId,
                        principalTable: "InventoryReceivingVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Supplier_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier",
                column: "InventoryReceivingVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_Supplier_SupplierId_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier",
                columns: new[] { "SupplierId", "InventoryReceivingVoucherId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryReceivingVoucher_Supplier");
        }
    }
}
