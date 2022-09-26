using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_InventoryDeliveryVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryDeliveryVoucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeDeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDeliveryVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Branches_BranchRequestId",
                        column: x => x.BranchRequestId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Employees_EmployeeDeliveryId",
                        column: x => x.EmployeeDeliveryId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Employees_EmployeeRequestId",
                        column: x => x.EmployeeRequestId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_BranchRequestId",
                table: "InventoryDeliveryVoucher",
                column: "BranchRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_CreatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_EmployeeDeliveryId",
                table: "InventoryDeliveryVoucher",
                column: "EmployeeDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_EmployeeRequestId",
                table: "InventoryDeliveryVoucher",
                column: "EmployeeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_UpdatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_WarehouseId",
                table: "InventoryDeliveryVoucher",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDeliveryVoucher");
        }
    }
}
