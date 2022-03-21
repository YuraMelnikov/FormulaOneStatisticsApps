using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Contexts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

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
        public DbSet<ParticipantImg> TeamImgs { get; set; }
        public DbSet<TeamName> TeamNames { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackСonfiguration> TrackСonfigurations { get; set; }
        public DbSet<Tyre> Tyres { get; set; }
    }
}
