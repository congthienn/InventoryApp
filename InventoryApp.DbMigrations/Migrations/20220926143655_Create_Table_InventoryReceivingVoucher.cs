using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryReceivingVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryReceivingVoucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeReceiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceivingVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Branches_BranchRequestId",
                        column: x => x.BranchRequestId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Employees_EmployeeReceiveId",
                        column: x => x.EmployeeReceiveId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Employees_EmployeeRequestId",
                        column: x => x.EmployeeRequestId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryReceivingVoucher_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_BranchRequestId",
                table: "InventoryReceivingVoucher",
                column: "BranchRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_CreatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_EmployeeReceiveId",
                table: "InventoryReceivingVoucher",
                column: "EmployeeReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_EmployeeRequestId",
                table: "InventoryReceivingVoucher",
                column: "EmployeeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_UpdatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceivingVoucher_WarehouseId",
                table: "InventoryReceivingVoucher",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryReceivingVoucher");
        }
    }
}
