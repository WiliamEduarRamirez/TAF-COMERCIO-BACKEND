using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addRelationsv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailEntry_Entry_EntryId",
                table: "DetailEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailEntry_Products_ProductId",
                table: "DetailEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Entry_Providers_ProviderId",
                table: "Entry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entry",
                table: "Entry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailEntry",
                table: "DetailEntry");

            migrationBuilder.RenameTable(
                name: "Entry",
                newName: "Entries");

            migrationBuilder.RenameTable(
                name: "DetailEntry",
                newName: "DetailEntries");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_ProviderId",
                table: "Entries",
                newName: "IX_Entries_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailEntry_ProductId",
                table: "DetailEntries",
                newName: "IX_DetailEntries_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailEntry_EntryId",
                table: "DetailEntries",
                newName: "IX_DetailEntries_EntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailEntries",
                table: "DetailEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailEntries_Entries_EntryId",
                table: "DetailEntries",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailEntries_Products_ProductId",
                table: "DetailEntries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailEntries_Entries_EntryId",
                table: "DetailEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailEntries_Products_ProductId",
                table: "DetailEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Providers_ProviderId",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailEntries",
                table: "DetailEntries");

            migrationBuilder.RenameTable(
                name: "Entries",
                newName: "Entry");

            migrationBuilder.RenameTable(
                name: "DetailEntries",
                newName: "DetailEntry");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ProviderId",
                table: "Entry",
                newName: "IX_Entry_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailEntries_ProductId",
                table: "DetailEntry",
                newName: "IX_DetailEntry_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailEntries_EntryId",
                table: "DetailEntry",
                newName: "IX_DetailEntry_EntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entry",
                table: "Entry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailEntry",
                table: "DetailEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailEntry_Entry_EntryId",
                table: "DetailEntry",
                column: "EntryId",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailEntry_Products_ProductId",
                table: "DetailEntry",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_Providers_ProviderId",
                table: "Entry",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
