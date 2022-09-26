using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryDeliveryVoucherDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryDeliveryVoucherDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryDeliveryVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuatityRequest = table.Column<int>(type: "int", nullable: false),
                    QuatityDelivery = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDeliveryVoucherDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                        column: x => x.InventoryDeliveryVoucherId,
                        principalTable: "InventoryDeliveryVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucherDetail_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucherDetail_MaterialUnit_MaterialUnitId",
                        column: x => x.MaterialUnitId,
                        principalTable: "MaterialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucherDetail_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucherDetail_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_CreatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail",
                column: "InventoryDeliveryVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_MaterialUnitId",
                table: "InventoryDeliveryVoucherDetail",
                column: "MaterialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucherDetail_UpdatedByUserId",
                table: "InventoryDeliveryVoucherDetail",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDeliveryVoucherDetail");
        }
    }
}
