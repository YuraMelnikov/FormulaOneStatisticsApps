using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Contexts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Season>(entity => { 
                entity.HasIndex(e => e.Year).IsUnique();
                entity.Property(p => p.Year).IsRequired();
                entity.Property(p => p.IdImage).IsRequired();
            });

            builder.AddRemoveOneToManyCascadeConvention();
        }

        public DbSet<ChampConstructorPastRace> ChampConstructorPastRace { get; set; }
        public DbSet<ChampRacersPastRace> ChampRacersPastRace { get; set; }
        public DbSet<SeasonRacersClassification> SeasonRacersClassification { get; set; }
        public DbSet<SeasonImg> SeasonImg { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<ChassisImg> ChassisImgs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineImg> EngineImgs { get; set; }
        public DbSet<FastLap> FastLaps { get; set; }
        public DbSet<GrandPrix> GrandPrixes { get; set; }
        public DbSet<GrandprixNote> GrandprixNotes { get; set; }
        public DbSet<GrandPrixImg> GrandPrixImgs { get; set; }
        public DbSet<GrandPrixResult> GrandPrixResults { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LeaderLap> LeaderLaps { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<RacerImg> RacerImgs { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ParticipantImg> ParticipantImg { get; set; }
        public DbSet<TeamName> TeamNames { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackСonfiguration> TrackСonfigurations { get; set; }
        public DbSet<SeasonManufacturersClassification> SeasonManufacturersClassification { get; set; }
        public DbSet<Tyre> Tyres { get; set; }
        public DbSet<GrandPrixNames> GrandPrixNames { get; set; }
        public DbSet<mytable> Mytable { get; set; }
    }
}
