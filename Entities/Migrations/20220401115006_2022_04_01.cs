using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeasonRacersClassification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSeason = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRacer = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonRacersClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonRacersClassification_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonRacersClassification_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRacersClassification_IdRacer",
                table: "SeasonRacersClassification",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRacersClassification_IdSeason",
                table: "SeasonRacersClassification",
                column: "IdSeason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonRacersClassification");
        }
    }
}
