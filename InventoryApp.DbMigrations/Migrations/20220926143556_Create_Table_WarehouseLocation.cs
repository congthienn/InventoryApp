using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_WarehouseLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseShelvesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseRackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehousePositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehouseArea_WarehouseAreaId",
                        column: x => x.WarehouseAreaId,
                        principalTable: "WarehouseArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehouseLine_WarehouseLineId",
                        column: x => x.WarehouseLineId,
                        principalTable: "WarehouseLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehousePosition_WarehousePositionId",
                        column: x => x.WarehousePositionId,
                        principalTable: "WarehousePosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehouseRack_WarehouseRackId",
                        column: x => x.WarehouseRackId,
                        principalTable: "WarehouseRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLocation_WarehouseShelves_WarehouseShelvesId",
                        column: x => x.WarehouseShelvesId,
                        principalTable: "WarehouseShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_CreatedByUserId",
                table: "WarehouseLocation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_UpdatedByUserId",
                table: "WarehouseLocation",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehouseAreaId",
                table: "WarehouseLocation",
                column: "WarehouseAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehouseId",
                table: "WarehouseLocation",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehouseLineId",
                table: "WarehouseLocation",
                column: "WarehouseLineId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehousePositionId",
                table: "WarehouseLocation",
                column: "WarehousePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehouseRackId",
                table: "WarehouseLocation",
                column: "WarehouseRackId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocation_WarehouseShelvesId",
                table: "WarehouseLocation",
                column: "WarehouseShelvesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseLocation");
        }
    }
}
