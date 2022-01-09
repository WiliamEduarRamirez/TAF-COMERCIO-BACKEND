using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddMoreType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_TypeId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_TypeId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId",
                unique: true);
        }
    }
}
