using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_11_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornIn",
                table: "Racer");

            migrationBuilder.DropColumn(
                name: "DeadIn",
                table: "Racer");

            migrationBuilder.DropColumn(
                name: "SecondNameRus",
                table: "Racer");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miles",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "TimeN",
                table: "GrandPrixResult");

            migrationBuilder.AddColumn<string>(
                name: "BornIn",
                table: "Racer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeadIn",
                table: "Racer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondNameRus",
                table: "Racer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
