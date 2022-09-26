using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityBalance = table.Column<int>(type: "int", nullable: false),
                    ExistingBalance = table.Column<int>(type: "int", nullable: false),
                    PeriodInput = table.Column<int>(type: "int", nullable: false),
                    PeriodOutput = table.Column<int>(type: "int", nullable: false),
                    BookingQuantity = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    LastBalanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryMaterialPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMaterial_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                        column: x => x.InventoryMaterialPeriodId,
                        principalTable: "InventoryMaterialPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterial_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterial_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterial_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterial_CreatedByUserId",
                table: "InventoryMaterial",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterial_InventoryMaterialPeriodId",
                table: "InventoryMaterial",
                column: "InventoryMaterialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterial_MaterialId",
                table: "InventoryMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterial_UpdatedByUserId",
                table: "InventoryMaterial",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterial_WarehouseLocationId",
                table: "InventoryMaterial",
                column: "WarehouseLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMaterial");
        }
    }
}
