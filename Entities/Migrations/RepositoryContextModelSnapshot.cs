﻿// <auto-generated />
using System;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Chassis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdLivery")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdManufacturer")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdLivery");

                    b.HasIndex("IdManufacturer");

                    b.ToTable("Chassis");
                });

            modelBuilder.Entity("Entities.Models.ChassisImg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdChassi")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdChassi");

                    b.HasIndex("IdImage");

                    b.ToTable("ChassisImg");
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Entities.Models.Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdManufacturer")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdManufacturer");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("Entities.Models.EngineImg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdEngine")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdEngine");

                    b.HasIndex("IdImage");

                    b.ToTable("EngineImg");
                });

            modelBuilder.Entity("Entities.Models.FastLap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AverageSpeed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uuid");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdParticipant");

                    b.ToTable("FastLap");
                });

            modelBuilder.Entity("Entities.Models.GrandPrix", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSeason")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdTrackСonfiguration")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("NumberInSeason")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfLap")
                        .HasColumnType("integer");

                    b.Property<float>("PercentDistance")
                        .HasColumnType("real");

                    b.Property<string>("Weather")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdSeason");

                    b.HasIndex("IdTrackСonfiguration");

                    b.ToTable("GrandPrix");
                });

            modelBuilder.Entity("Entities.Models.GrandPrixImg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdGrandPrix")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdGrandPrix");

                    b.HasIndex("IdImage");

                    b.ToTable("GrandPrixImg");
                });

            modelBuilder.Entity("Entities.Models.GrandprixNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdGrandPrix")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdGrandPrix");

                    b.ToTable("GrandprixNote");
                });

            modelBuilder.Entity("Entities.Models.GrandPrixResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AverageSpeed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uuid");

                    b.Property<int?>("Lap")
                        .HasColumnType("integer");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<int?>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdParticipant");

                    b.ToTable("GrandPrixResult");
                });

            modelBuilder.Entity("Entities.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Entities.Models.LeaderLap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("First")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uuid");

                    b.Property<int>("Last")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdParticipant");

                    b.ToTable("LeaderLap");
                });

            modelBuilder.Entity("Entities.Models.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCountry")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdImage");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Entities.Models.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdChassis")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdEngine")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdGrandPrix")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRacer")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdTeam")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdTyre")
                        .HasColumnType("uuid");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdChassis");

                    b.HasIndex("IdEngine");

                    b.HasIndex("IdGrandPrix");

                    b.HasIndex("IdRacer");

                    b.HasIndex("IdTeam");

                    b.HasIndex("IdTyre");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Entities.Models.ParticipantImg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdParticipant");

                    b.ToTable("ParticipantImg");
                });

            modelBuilder.Entity("Entities.Models.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdParticipant")
                        .HasColumnType("uuid");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdParticipant");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("Entities.Models.Racer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Born")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BornIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Dead")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeadIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstNameRus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdCountry")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondNameRus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TextData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdImage");

                    b.ToTable("Racer");
                });

            modelBuilder.Entity("Entities.Models.RacerImg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRacer")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdRacer");

                    b.ToTable("RacerImg");
                });

            modelBuilder.Entity("Entities.Models.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("Year")
                        .IsUnique();

                    b.ToTable("Season");
                });

            modelBuilder.Entity("Entities.Models.SeasonRacersClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRacer")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSeason")
                        .HasColumnType("uuid");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdRacer");

                    b.HasIndex("IdSeason");

                    b.ToTable("SeasonRacersClassification");
                });

            modelBuilder.Entity("Entities.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCountry")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdImage");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Entities.Models.TeamName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdSeason")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdTeam")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdSeason");

                    b.HasIndex("IdTeam");

                    b.ToTable("TeamName");
                });

            modelBuilder.Entity("Entities.Models.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCountry")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameRus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdImage");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Entities.Models.TrackСonfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdTrack")
                        .HasColumnType("uuid");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdTrack");

                    b.ToTable("TrackСonfiguration");
                });

            modelBuilder.Entity("Entities.Models.Tyre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdImage")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdManufacturer")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdManufacturer");

                    b.ToTable("Tyre");
                });

            modelBuilder.Entity("Entities.Models.Chassis", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Livery")
                        .WithMany()
                        .HasForeignKey("IdLivery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("IdManufacturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Livery");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Entities.Models.ChassisImg", b =>
                {
                    b.HasOne("Entities.Models.Chassis", "Chassi")
                        .WithMany()
                        .HasForeignKey("IdChassi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chassi");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.Country", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.Engine", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("IdManufacturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Entities.Models.EngineImg", b =>
                {
                    b.HasOne("Entities.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("IdEngine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.FastLap", b =>
                {
                    b.HasOne("Entities.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Entities.Models.GrandPrix", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Season", "Season")
                        .WithMany()
                        .HasForeignKey("IdSeason")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.TrackСonfiguration", "TrackСonfiguration")
                        .WithMany()
                        .HasForeignKey("IdTrackСonfiguration")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Season");

                    b.Navigation("TrackСonfiguration");
                });

            modelBuilder.Entity("Entities.Models.GrandPrixImg", b =>
                {
                    b.HasOne("Entities.Models.GrandPrix", "GrandPrix")
                        .WithMany()
                        .HasForeignKey("IdGrandPrix")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrandPrix");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.GrandprixNote", b =>
                {
                    b.HasOne("Entities.Models.GrandPrix", "GrandPrix")
                        .WithMany()
                        .HasForeignKey("IdGrandPrix")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrandPrix");
                });

            modelBuilder.Entity("Entities.Models.GrandPrixResult", b =>
                {
                    b.HasOne("Entities.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Entities.Models.LeaderLap", b =>
                {
                    b.HasOne("Entities.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Entities.Models.Manufacturer", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.Participant", b =>
                {
                    b.HasOne("Entities.Models.Chassis", "Chassis")
                        .WithMany()
                        .HasForeignKey("IdChassis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("IdEngine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.GrandPrix", "GrandPrix")
                        .WithMany()
                        .HasForeignKey("IdGrandPrix")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Racer", "Racer")
                        .WithMany()
                        .HasForeignKey("IdRacer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Tyre", "Tyre")
                        .WithMany()
                        .HasForeignKey("IdTyre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chassis");

                    b.Navigation("Engine");

                    b.Navigation("GrandPrix");

                    b.Navigation("Racer");

                    b.Navigation("Team");

                    b.Navigation("Tyre");
                });

            modelBuilder.Entity("Entities.Models.ParticipantImg", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Entities.Models.Qualification", b =>
                {
                    b.HasOne("Entities.Models.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("IdParticipant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Entities.Models.Racer", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.RacerImg", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Racer", "Racer")
                        .WithMany()
                        .HasForeignKey("IdRacer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Racer");
                });

            modelBuilder.Entity("Entities.Models.Season", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.SeasonRacersClassification", b =>
                {
                    b.HasOne("Entities.Models.Racer", "Racer")
                        .WithMany()
                        .HasForeignKey("IdRacer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Season", "Season")
                        .WithMany()
                        .HasForeignKey("IdSeason")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racer");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Entities.Models.Team", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.TeamName", b =>
                {
                    b.HasOne("Entities.Models.Season", "Season")
                        .WithMany()
                        .HasForeignKey("IdSeason")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Entities.Models.Track", b =>
                {
                    b.HasOne("Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Entities.Models.TrackСonfiguration", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Entities.Models.Tyre", b =>
                {
                    b.HasOne("Entities.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("IdManufacturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
