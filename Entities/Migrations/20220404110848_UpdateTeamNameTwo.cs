using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class UpdateTeamNameTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdCountry",
                table: "TeamName",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdCountry",
                table: "TeamName",
                column: "IdCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamName_Country_IdCountry",
                table: "TeamName",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamName_Country_IdCountry",
                table: "TeamName");

            migrationBuilder.DropIndex(
                name: "IX_TeamName_IdCountry",
                table: "TeamName");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCountry",
                table: "TeamName",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
