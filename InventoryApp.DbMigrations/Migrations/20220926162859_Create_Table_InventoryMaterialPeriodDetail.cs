using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryMaterialPeriodDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryMaterialPeriodDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryMaterialPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExistingBalance = table.Column<int>(type: "int", nullable: false),
                    PeriodInput = table.Column<int>(type: "int", nullable: false),
                    PeriodOutput = table.Column<int>(type: "int", nullable: false),
                    QuantityBalance = table.Column<int>(type: "int", nullable: false),
                    LastBalanceDate = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMaterialPeriodDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMaterialPeriodDetail_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                        column: x => x.InventoryMaterialPeriodId,
                        principalTable: "InventoryMaterialPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterialPeriodDetail_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterialPeriodDetail_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterialPeriodDetail_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMaterialPeriodDetail_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterialPeriodDetail_CreatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterialPeriodDetail_InventoryMaterialPeriodId",
                table: "InventoryMaterialPeriodDetail",
                column: "InventoryMaterialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterialPeriodDetail_MaterialId",
                table: "InventoryMaterialPeriodDetail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterialPeriodDetail_UpdatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMaterialPeriodDetail_WarehouseId",
                table: "InventoryMaterialPeriodDetail",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMaterialPeriodDetail");
        }
    }
}
