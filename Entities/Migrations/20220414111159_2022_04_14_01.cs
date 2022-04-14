using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_14_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "Racer");

            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "Miles",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "TimeN",
                table: "GrandPrixResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdate",
                table: "Racer",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdate",
                table: "Participant",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdate",
                table: "GrandPrixResult",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Miles",
                table: "GrandPrixResult",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeN",
                table: "GrandPrixResult",
                type: "text",
                nullable: true);
        }
    }
}
