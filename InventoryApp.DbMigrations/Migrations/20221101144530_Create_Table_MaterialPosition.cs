using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_MaterialPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseShelveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialPosition_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialPosition_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialPosition_WarehouseShelves_WarehouseShelveId",
                        column: x => x.WarehouseShelveId,
                        principalTable: "WarehouseShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPosition_BranchId",
                table: "MaterialPosition",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPosition_MaterialId",
                table: "MaterialPosition",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPosition_WarehouseShelveId",
                table: "MaterialPosition",
                column: "WarehouseShelveId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialPosition");
        }
    }
}
