using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_21_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdGrandPrixNames",
                table: "GrandPrix",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdGrandPrixNames",
                table: "GrandPrix",
                column: "IdGrandPrixNames");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix",
                column: "IdGrandPrixNames",
                principalTable: "GrandPrixNames",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix");

            migrationBuilder.DropIndex(
                name: "IX_GrandPrix_IdGrandPrixNames",
                table: "GrandPrix");

            migrationBuilder.DropColumn(
                name: "IdGrandPrixNames",
                table: "GrandPrix");
        }
    }
}
