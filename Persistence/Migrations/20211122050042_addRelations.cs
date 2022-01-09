using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Providers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MarkId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DocumentType = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProviderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entry_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailEntry_Entry_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailEntry_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkId",
                table: "Products",
                column: "MarkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailEntry_EntryId",
                table: "DetailEntry",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailEntry_ProductId",
                table: "DetailEntry",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_ProviderId",
                table: "Entry",
                column: "ProviderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products",
                column: "MarkId",
                principalTable: "Marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marks_MarkId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DetailEntry");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "Products");
        }
    }
}
