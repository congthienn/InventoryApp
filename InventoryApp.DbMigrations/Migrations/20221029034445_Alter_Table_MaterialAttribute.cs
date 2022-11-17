using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Alter_Table_MaterialAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialAttribute",
                table: "MaterialAttribute");

            migrationBuilder.DropIndex(
                name: "IX_MaterialAttribute_CodeName",
                table: "MaterialAttribute");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "MaterialAttribute");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "MaterialAttribute");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaterialAttribute",
                newName: "MaterialsCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MaterialAttribute",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaterialAttributeId",
                table: "MaterialAttribute",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialAttribute",
                table: "MaterialAttribute",
                column: "MaterialAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttribute_MaterialsCategoryId",
                table: "MaterialAttribute",
                column: "MaterialsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttribute_Name_MaterialsCategoryId",
                table: "MaterialAttribute",
                columns: new[] { "Name", "MaterialsCategoryId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute",
                column: "MaterialsCategoryId",
                principalTable: "CategoryMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialAttribute",
                table: "MaterialAttribute");

            migrationBuilder.DropIndex(
                name: "IX_MaterialAttribute_MaterialsCategoryId",
                table: "MaterialAttribute");

            migrationBuilder.DropIndex(
                name: "IX_MaterialAttribute_Name_MaterialsCategoryId",
                table: "MaterialAttribute");

            migrationBuilder.DropColumn(
                name: "MaterialAttributeId",
                table: "MaterialAttribute");

            migrationBuilder.RenameColumn(
                name: "MaterialsCategoryId",
                table: "MaterialAttribute",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MaterialAttribute",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "MaterialAttribute",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "MaterialAttribute",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialAttribute",
                table: "MaterialAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttribute_CodeName",
                table: "MaterialAttribute",
                column: "CodeName",
                unique: true);
        }
    }
}
