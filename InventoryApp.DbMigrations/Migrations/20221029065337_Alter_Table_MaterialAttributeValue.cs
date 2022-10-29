using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_MaterialAttributeValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialAttributeValues",
                columns: table => new
                {
                    MaterialAttributeId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAttributeValues", x => new { x.MaterialId, x.MaterialAttributeId });
                    table.ForeignKey(
                        name: "FK_MaterialAttributeValues_MaterialAttribute_MaterialAttributeId",
                        column: x => x.MaterialAttributeId,
                        principalTable: "MaterialAttribute",
                        principalColumn: "MaterialAttributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialAttributeValues_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialAttributeValues_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialAttributeValues_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttributeValues_CreatedByUserId",
                table: "MaterialAttributeValues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttributeValues_MaterialAttributeId",
                table: "MaterialAttributeValues",
                column: "MaterialAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttributeValues_UpdatedByUserId",
                table: "MaterialAttributeValues",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialAttributeValues");
        }
    }
}
