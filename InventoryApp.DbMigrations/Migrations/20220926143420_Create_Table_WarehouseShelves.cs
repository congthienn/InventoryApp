using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_WarehouseShelves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseShelves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseShelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseShelves_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseShelves_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseShelves_WarehouseLine_WarehouseLineId",
                        column: x => x.WarehouseLineId,
                        principalTable: "WarehouseLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_Code",
                table: "WarehouseShelves",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_CreatedByUserId",
                table: "WarehouseShelves",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_UpdatedByUserId",
                table: "WarehouseShelves",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShelves_WarehouseLineId",
                table: "WarehouseShelves",
                column: "WarehouseLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseShelves");
        }
    }
}
