using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_21_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GrandPrix");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdGrandPrixNames",
                table: "GrandPrix",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix",
                column: "IdGrandPrixNames",
                principalTable: "GrandPrixNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdGrandPrixNames",
                table: "GrandPrix",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GrandPrix",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                table: "GrandPrix",
                column: "IdGrandPrixNames",
                principalTable: "GrandPrixNames",
                principalColumn: "Id");
        }
    }
}
