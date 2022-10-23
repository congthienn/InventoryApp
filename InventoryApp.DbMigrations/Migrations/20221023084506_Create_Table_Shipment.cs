using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_Shipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipment_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_Code",
                table: "Shipment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_CreatedByUserId",
                table: "Shipment",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_UpdatedByUserId",
                table: "Shipment",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipment");
        }
    }
}
