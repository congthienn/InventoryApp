using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryReceivingVoucherDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryReceivingVoucherDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryReceivingVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuatityRequest = table.Column<int>(type: "int", nullable: false),
                    QuatityReceiving = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceivingVoucherDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucherDetail_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                        column: x => x.InventoryReceivingVoucherId,
                        principalTable: "InventoryReceivingVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucherDetail_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucherDetail_MaterialUnit_MaterialUnitId",
                        column: x => x.MaterialUnitId,
                        principalTable: "MaterialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucherDetail_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucherDetail_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_CreatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_MaterialUnitId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucherDetail_UpdatedByUserId",
                table: "InventoryReceivingVoucherDetail",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryReceivingVoucherDetail");
        }
    }
}
