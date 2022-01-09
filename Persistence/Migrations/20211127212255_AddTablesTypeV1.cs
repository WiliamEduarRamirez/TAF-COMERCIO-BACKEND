using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddTablesTypeV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_TypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Types");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "OrderDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "State",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Type_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
