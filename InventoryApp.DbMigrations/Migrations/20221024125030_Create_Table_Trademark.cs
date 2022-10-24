using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_Trademark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Manufacturer_ManufacturerId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Materials",
                newName: "TrademarkId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_ManufacturerId",
                table: "Materials",
                newName: "IX_Materials_TrademarkId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CategoryMaterial",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Trademark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trademark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trademark_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trademark_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMaterial_Code",
                table: "CategoryMaterial",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trademark_CreatedByUserId",
                table: "Trademark",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trademark_UpdatedByUserId",
                table: "Trademark",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials",
                column: "TrademarkId",
                principalTable: "Trademark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "Trademark");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMaterial_Code",
                table: "CategoryMaterial");

            migrationBuilder.RenameColumn(
                name: "TrademarkId",
                table: "Materials",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_TrademarkId",
                table: "Materials",
                newName: "IX_Materials_ManufacturerId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CategoryMaterial",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ForeignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_CompaniesId",
                table: "Manufacturer",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_CreatedByUserId",
                table: "Manufacturer",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_DistrictId",
                table: "Manufacturer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Email",
                table: "Manufacturer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_ProvinceId",
                table: "Manufacturer",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_UpdatedByUserId",
                table: "Manufacturer",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_WardId",
                table: "Manufacturer",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Manufacturer_ManufacturerId",
                table: "Materials",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
