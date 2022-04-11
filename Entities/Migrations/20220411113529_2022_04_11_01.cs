using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_11_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "PercentDistance",
                table: "GrandPrix");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdate",
                table: "Racer",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdate",
                table: "Qualification",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "Racer");

            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "IsUpdate",
                table: "GrandPrixResult");

            migrationBuilder.AddColumn<float>(
                name: "Points",
                table: "Qualification",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PercentDistance",
                table: "GrandPrix",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
