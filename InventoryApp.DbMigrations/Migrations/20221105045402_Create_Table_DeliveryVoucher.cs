using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Create_Table_DeliveryVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDeliveryVoucher_Customer");

            migrationBuilder.RenameColumn(
                name: "QuatityRequest",
                table: "InventoryReceivingVoucherDetail",
                newName: "QuantityRequest");

            migrationBuilder.RenameColumn(
                name: "QuatityReceiving",
                table: "InventoryReceivingVoucherDetail",
                newName: "QuantityReceiving");

            migrationBuilder.RenameColumn(
                name: "QuatityRequest",
                table: "InventoryDeliveryVoucherDetail",
                newName: "QuantityRequest");

            migrationBuilder.RenameColumn(
                name: "QuatityDelivery",
                table: "InventoryDeliveryVoucherDetail",
                newName: "QuantityDelivery");

            migrationBuilder.AddColumn<DateTime>(
                name: "GoodsIssueDate",
                table: "InventoryDeliveryVoucher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryVoucher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryDeliveryVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialPrice = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DeliveryUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryVoucher_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryVoucher_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                        column: x => x.InventoryDeliveryVoucherId,
                        principalTable: "InventoryDeliveryVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryVoucher_Users_DeliveryUserId",
                        column: x => x.DeliveryUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVoucher_Code",
                table: "DeliveryVoucher",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVoucher_CustomerId_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher",
                columns: new[] { "CustomerId", "InventoryDeliveryVoucherId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVoucher_DeliveryUserId",
                table: "DeliveryVoucher",
                column: "DeliveryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVoucher_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher",
                column: "InventoryDeliveryVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryVoucher");

            migrationBuilder.DropColumn(
                name: "GoodsIssueDate",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.RenameColumn(
                name: "QuantityRequest",
                table: "InventoryReceivingVoucherDetail",
                newName: "QuatityRequest");

            migrationBuilder.RenameColumn(
                name: "QuantityReceiving",
                table: "InventoryReceivingVoucherDetail",
                newName: "QuatityReceiving");

            migrationBuilder.RenameColumn(
                name: "QuantityRequest",
                table: "InventoryDeliveryVoucherDetail",
                newName: "QuatityRequest");

            migrationBuilder.RenameColumn(
                name: "QuantityDelivery",
                table: "InventoryDeliveryVoucherDetail",
                newName: "QuatityDelivery");

            migrationBuilder.CreateTable(
                name: "InventoryDeliveryVoucher_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryDeliveryVoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDeliveryVoucher_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Customer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDeliveryVoucher_Customer_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                        column: x => x.InventoryDeliveryVoucherId,
                        principalTable: "InventoryDeliveryVoucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_Customer_CustomerId_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucher_Customer",
                columns: new[] { "CustomerId", "InventoryDeliveryVoucherId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDeliveryVoucher_Customer_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucher_Customer",
                column: "InventoryDeliveryVoucherId");
        }
    }
}
