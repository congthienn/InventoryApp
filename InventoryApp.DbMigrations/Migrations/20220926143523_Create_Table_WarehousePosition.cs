using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_WarehousePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehousePosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseRackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehousePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehousePosition_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehousePosition_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehousePosition_WarehouseRack_WarehouseRackId",
                        column: x => x.WarehouseRackId,
                        principalTable: "WarehouseRack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePosition_Code",
                table: "WarehousePosition",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePosition_CreatedByUserId",
                table: "WarehousePosition",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePosition_UpdatedByUserId",
                table: "WarehousePosition",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePosition_WarehouseRackId",
                table: "WarehousePosition",
                column: "WarehouseRackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehousePosition");
        }
    }
}
