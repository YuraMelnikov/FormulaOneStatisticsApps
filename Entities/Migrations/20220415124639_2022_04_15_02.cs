using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_15_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampConstructorPastRace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrix = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTeamName = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampConstructorPastRace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampConstructorPastRace_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampConstructorPastRace_TeamName_IdTeamName",
                        column: x => x.IdTeamName,
                        principalTable: "TeamName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampRacersPastRace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrix = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRacer = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampRacersPastRace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampRacersPastRace_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampRacersPastRace_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampConstructorPastRace_IdGrandPrix",
                table: "ChampConstructorPastRace",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_ChampConstructorPastRace_IdTeamName",
                table: "ChampConstructorPastRace",
                column: "IdTeamName");

            migrationBuilder.CreateIndex(
                name: "IX_ChampRacersPastRace_IdGrandPrix",
                table: "ChampRacersPastRace",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_ChampRacersPastRace_IdRacer",
                table: "ChampRacersPastRace",
                column: "IdRacer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampConstructorPastRace");

            migrationBuilder.DropTable(
                name: "ChampRacersPastRace");
        }
    }
}
