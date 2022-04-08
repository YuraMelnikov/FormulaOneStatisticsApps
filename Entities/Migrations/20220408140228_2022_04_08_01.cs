using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class _2022_04_08_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeasonImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSeason = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonImg_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonImg_IdImage",
                table: "SeasonImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonImg_IdSeason",
                table: "SeasonImg",
                column: "IdSeason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonImg");
        }
    }
}
