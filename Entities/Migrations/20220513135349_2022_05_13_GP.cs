using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_05_13_GP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Track",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FastestLap",
                table: "GrandPrixResult",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FastestLapSpeed",
                table: "GrandPrixResult",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FastestLapTime",
                table: "GrandPrixResult",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeLag",
                table: "GrandPrixResult",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "FastestLap",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "FastestLapSpeed",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "FastestLapTime",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "TimeLag",
                table: "GrandPrixResult");
        }
    }
}
