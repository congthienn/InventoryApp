using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppelationOfForeignTrader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Code",
                table: "Supplier",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CreatedByUserId",
                table: "Supplier",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DistrictId",
                table: "Supplier",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Email",
                table: "Supplier",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Fax",
                table: "Supplier",
                column: "Fax",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_PhoneNumber",
                table: "Supplier",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProvinceId",
                table: "Supplier",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_TaxCode",
                table: "Supplier",
                column: "TaxCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UpdatedByUserId",
                table: "Supplier",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_WardId",
                table: "Supplier",
                column: "WardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
