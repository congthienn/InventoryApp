using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_WarehouseLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseLine_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLine_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseLine_WarehouseArea_WarehouseAreaId",
                        column: x => x.WarehouseAreaId,
                        principalTable: "WarehouseArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_Code",
                table: "WarehouseLine",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_CreatedByUserId",
                table: "WarehouseLine",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_UpdatedByUserId",
                table: "WarehouseLine",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLine_WarehouseAreaId",
                table: "WarehouseLine",
                column: "WarehouseAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseLine");
        }
    }
}
