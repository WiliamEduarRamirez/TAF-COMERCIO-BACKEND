using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddRelationCategoryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TypeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Categories");
        }
    }
}
