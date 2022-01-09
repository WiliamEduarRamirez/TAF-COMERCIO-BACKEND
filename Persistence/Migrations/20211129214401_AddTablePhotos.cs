using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddTablePhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Photos");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Photos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ProductId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Photos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Photos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
