using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrandPrixNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameRu = table.Column<string>(type: "text", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uuid", nullable: false),
                    Born = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dead = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    FirstNameRus = table.Column<string>(type: "text", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    TextData = table.Column<string>(type: "text", nullable: false),
                    TimeApiId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racer_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racer_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImageLogo = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeApiId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamName_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamName_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamName_Image_IdImageLogo",
                        column: x => x.IdImageLogo,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameRus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Chassis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdManufacturer = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLivery = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chassis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chassis_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassis_Image_IdLivery",
                        column: x => x.IdLivery,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassis_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdManufacturer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engine_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engine_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tyre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdManufacturer = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tyre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tyre_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tyre_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacerImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRacer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacerImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacerImg_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SeasonManufacturersClassification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSeason = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTeamName = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonManufacturersClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonManufacturersClassification_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonManufacturersClassification_TeamName_IdTeamName",
                        column: x => x.IdTeamName,
                        principalTable: "TeamName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackСonfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTrack = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackСonfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackСonfiguration_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackСonfiguration_Track_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChassisImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChassi = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassisImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChassisImg_Chassis_IdChassi",
                        column: x => x.IdChassi,
                        principalTable: "Chassis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChassisImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEngine = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineImg_Engine_IdEngine",
                        column: x => x.IdEngine,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSeason = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTrackСonfiguration = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    NumberInSeason = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    Weather = table.Column<string>(type: "text", nullable: false),
                    NumberOfLap = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IdGrandPrixNames = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrix_GrandPrixNames_IdGrandPrixNames",
                        column: x => x.IdGrandPrixNames,
                        principalTable: "GrandPrixNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrix_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrix_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrix_TrackСonfiguration_IdTrackСonfiguration",
                        column: x => x.IdTrackСonfiguration,
                        principalTable: "TrackСonfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "GrandPrixImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrix = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixImg_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrixImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandprixNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrix = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandprixNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandprixNote_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrix = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    IdTeam = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChassis = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEngine = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRacer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTyre = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTeamName = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Chassis_IdChassis",
                        column: x => x.IdChassis,
                        principalTable: "Chassis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Engine_IdEngine",
                        column: x => x.IdEngine,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Tyre_IdTyre",
                        column: x => x.IdTyre,
                        principalTable: "Tyre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FastLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParticipant = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    AverageSpeed = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FastLap_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrixResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParticipant = table.Column<Guid>(type: "uuid", nullable: false),
                    Classification = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    AverageSpeed = table.Column<string>(type: "text", nullable: false),
                    Lap = table.Column<int>(type: "integer", nullable: true),
                    Points = table.Column<float>(type: "real", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: false),
                    NoteRus = table.Column<string>(type: "text", nullable: false),
                    ClassificationRus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixResult_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaderLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParticipant = table.Column<Guid>(type: "uuid", nullable: false),
                    First = table.Column<int>(type: "integer", nullable: false),
                    Last = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderLap_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParticipant = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantImg_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdParticipant = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    IsUpdate = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualification_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
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

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_IdImage",
                table: "Chassis",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_IdLivery",
                table: "Chassis",
                column: "IdLivery");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_IdManufacturer",
                table: "Chassis",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_ChassisImg_IdChassi",
                table: "ChassisImg",
                column: "IdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_ChassisImg_IdImage",
                table: "ChassisImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdImage",
                table: "Country",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdImage",
                table: "Engine",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdManufacturer",
                table: "Engine",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_EngineImg_IdEngine",
                table: "EngineImg",
                column: "IdEngine");

            migrationBuilder.CreateIndex(
                name: "IX_EngineImg_IdImage",
                table: "EngineImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_FastLap_IdParticipant",
                table: "FastLap",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdGrandPrixNames",
                table: "GrandPrix",
                column: "IdGrandPrixNames");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdImage",
                table: "GrandPrix",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdSeason",
                table: "GrandPrix",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdTrackСonfiguration",
                table: "GrandPrix",
                column: "IdTrackСonfiguration");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixImg_IdGrandPrix",
                table: "GrandPrixImg",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixImg_IdImage",
                table: "GrandPrixImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_GrandprixNote_IdGrandPrix",
                table: "GrandprixNote",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixResult_IdParticipant",
                table: "GrandPrixResult",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderLap_IdParticipant",
                table: "LeaderLap",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdCountry",
                table: "Manufacturer",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdImage",
                table: "Manufacturer",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdChassis",
                table: "Participant",
                column: "IdChassis");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdEngine",
                table: "Participant",
                column: "IdEngine");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdGrandPrix",
                table: "Participant",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdRacer",
                table: "Participant",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdTeam",
                table: "Participant",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdTyre",
                table: "Participant",
                column: "IdTyre");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantImg_IdImage",
                table: "ParticipantImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantImg_IdParticipant",
                table: "ParticipantImg",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_IdParticipant",
                table: "Qualification",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_Racer_IdCountry",
                table: "Racer",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Racer_IdImage",
                table: "Racer",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_RacerImg_IdImage",
                table: "RacerImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_RacerImg_IdRacer",
                table: "RacerImg",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_Season_IdImage",
                table: "Season",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Season_Year",
                table: "Season",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonImg_IdImage",
                table: "SeasonImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonImg_IdSeason",
                table: "SeasonImg",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonManufacturersClassification_IdSeason",
                table: "SeasonManufacturersClassification",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonManufacturersClassification_IdTeamName",
                table: "SeasonManufacturersClassification",
                column: "IdTeamName");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRacersClassification_IdRacer",
                table: "SeasonRacersClassification",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonRacersClassification_IdSeason",
                table: "SeasonRacersClassification",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdCountry",
                table: "TeamName",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdImage",
                table: "TeamName",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdImageLogo",
                table: "TeamName",
                column: "IdImageLogo");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdCountry",
                table: "Track",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdImage",
                table: "Track",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TrackСonfiguration_IdImage",
                table: "TrackСonfiguration",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TrackСonfiguration_IdTrack",
                table: "TrackСonfiguration",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tyre_IdImage",
                table: "Tyre",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Tyre_IdManufacturer",
                table: "Tyre",
                column: "IdManufacturer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampConstructorPastRace");

            migrationBuilder.DropTable(
                name: "ChampRacersPastRace");

            migrationBuilder.DropTable(
                name: "ChassisImg");

            migrationBuilder.DropTable(
                name: "EngineImg");

            migrationBuilder.DropTable(
                name: "FastLap");

            migrationBuilder.DropTable(
                name: "GrandPrixImg");

            migrationBuilder.DropTable(
                name: "GrandprixNote");

            migrationBuilder.DropTable(
                name: "GrandPrixResult");

            migrationBuilder.DropTable(
                name: "LeaderLap");

            migrationBuilder.DropTable(
                name: "ParticipantImg");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "RacerImg");

            migrationBuilder.DropTable(
                name: "SeasonImg");

            migrationBuilder.DropTable(
                name: "SeasonManufacturersClassification");

            migrationBuilder.DropTable(
                name: "SeasonRacersClassification");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "TeamName");

            migrationBuilder.DropTable(
                name: "Chassis");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "GrandPrix");

            migrationBuilder.DropTable(
                name: "Racer");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Tyre");

            migrationBuilder.DropTable(
                name: "GrandPrixNames");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "TrackСonfiguration");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
