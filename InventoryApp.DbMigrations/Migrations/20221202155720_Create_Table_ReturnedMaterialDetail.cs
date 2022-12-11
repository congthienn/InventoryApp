using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_ReturnedMaterialDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReturnedMaterialDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnedMaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedMaterialDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnedMaterialDetail_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnedMaterialDetail_ReturnedMaterial_ReturnedMaterialId",
                        column: x => x.ReturnedMaterialId,
                        principalTable: "ReturnedMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedMaterialDetail_MaterialId_ReturnedMaterialId",
                table: "ReturnedMaterialDetail",
                columns: new[] { "MaterialId", "ReturnedMaterialId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedMaterialDetail_ReturnedMaterialId",
                table: "ReturnedMaterialDetail",
                column: "ReturnedMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnedMaterialDetail");
        }
    }
}
