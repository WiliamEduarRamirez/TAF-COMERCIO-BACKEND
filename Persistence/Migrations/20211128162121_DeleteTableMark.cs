using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DeleteTableMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarkId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Denomination = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkId",
                table: "Products",
                column: "MarkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
