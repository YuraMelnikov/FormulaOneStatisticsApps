using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class UpdateTeamNameT9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassificationRus",
                table: "GrandPrixResult",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteRus",
                table: "GrandPrixResult",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificationRus",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "NoteRus",
                table: "GrandPrixResult");
        }
    }
}
