using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_Materials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumInventory = table.Column<int>(type: "int", nullable: false),
                    MaximumInventory = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_CategoryMaterial_CategoryMaterialId",
                        column: x => x.CategoryMaterialId,
                        principalTable: "CategoryMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialUnit_MaterialUnitId",
                        column: x => x.MaterialUnitId,
                        principalTable: "MaterialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryMaterialId",
                table: "Materials",
                column: "CategoryMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ManufacturerId",
                table: "Materials",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialUnitId",
                table: "Materials",
                column: "MaterialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UpdatedByUserId",
                table: "Materials",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
