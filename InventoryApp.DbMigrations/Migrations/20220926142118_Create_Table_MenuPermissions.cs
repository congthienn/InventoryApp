using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_MenuPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationsMenu = table.Column<bool>(type: "bit", nullable: false),
                    CreateQuotationMenu = table.Column<bool>(type: "bit", nullable: false),
                    RulesQuotationMenu = table.Column<bool>(type: "bit", nullable: false),
                    CustomerQuotaionMenu = table.Column<bool>(type: "bit", nullable: false),
                    MonthlyReportQuotaionMenu = table.Column<bool>(type: "bit", nullable: false),
                    SummarizeReportQuotaionMenu = table.Column<bool>(type: "bit", nullable: false),
                    ShippingCostQuotationMenu = table.Column<bool>(type: "bit", nullable: false),
                    ContractsMenu = table.Column<bool>(type: "bit", nullable: false),
                    CreateContractMenu = table.Column<bool>(type: "bit", nullable: false),
                    ContractTemplateMenu = table.Column<bool>(type: "bit", nullable: false),
                    OrdersMenu = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrderMenu = table.Column<bool>(type: "bit", nullable: false),
                    BillMenu = table.Column<bool>(type: "bit", nullable: false),
                    OrderReportMenu = table.Column<bool>(type: "bit", nullable: false),
                    LibraryMenu = table.Column<bool>(type: "bit", nullable: false),
                    CustomerLibraryMenu = table.Column<bool>(type: "bit", nullable: false),
                    OtherMenu = table.Column<bool>(type: "bit", nullable: false),
                    HRMMenu = table.Column<bool>(type: "bit", nullable: false),
                    UserMenu = table.Column<bool>(type: "bit", nullable: false),
                    AssetMenu = table.Column<bool>(type: "bit", nullable: false),
                    SystemMenu = table.Column<bool>(type: "bit", nullable: false),
                    StructureMenu = table.Column<bool>(type: "bit", nullable: false),
                    InventoryMenu = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseMenu = table.Column<bool>(type: "bit", nullable: false),
                    ServiceMenu = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_CreatedByUserId",
                table: "MenuPermissions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_PermissionGroupId",
                table: "MenuPermissions",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_UpdatedByUserId",
                table: "MenuPermissions",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuPermissions");
        }
    }
}
