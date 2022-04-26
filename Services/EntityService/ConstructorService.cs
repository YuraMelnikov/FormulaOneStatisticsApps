using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ConstructorService : IConstructorService
    {
        private readonly RepositoryContext _repositoryContext;

        public ConstructorService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<ConstructorChampionshipDto>> GetClassification(Guid constructorId)
        {
            var query = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Where(a => a.Participant.IdTeamName == constructorId)
                .OrderBy(a => a.Participant.GrandPrix.Number)
                .Select(a => new
                {
                    Id = a.Participant.IdGrandPrix,
                    Name = a.Participant.GrandPrix.GrandPrixName.ShortName,
                    Classification = a.Classification,
                    Season = a.Participant.GrandPrix.Season.Year,
                    SeasonCllasification = _repositoryContext.SeasonManufacturersClassification
                        .AsNoTracking()
                        .Where(b => b.IdTeamName == constructorId && b.IdSeason == a.Participant.GrandPrix.IdSeason)
                        .Select(b => new PositionWithPoints
                        {
                            Points = b.Points,
                            Position = b.Position
                        })
                        .FirstOrDefault()
                })
                .ToArrayAsync();

            var result = (from season in query
                    group season by season.Season into g
                    select new ConstructorChampionshipDto
                    {
                        Season = g.Key,

                        Points = (from p in g select p.SeasonCllasification).Max(p => p?.Points ?? 0),
                        Position = (from p in g select p.SeasonCllasification).Max(p => p?.Position ?? 0),

                        Result = (from p in g
                                  select new ConstructorChampColumnDto
                                  {
                                      Id = p.Id,
                                      Name = p.Name
                                  }).Distinct()
                                  .Select(n => new ConstructorChampColumnDto
                                  {
                                      Id = n.Id, 
                                      Name = n.Name, 
                                      Position = g.Where(g => g.Id == n.Id && g.Name == n.Name)
                                      .Select(g => g.Classification)
                                      .ToArray()
                                  })
                    }).ToArray();

            return result;
        }

        public async Task<IEnumerable<ImageDto>> GetImages(Guid constructorId) =>
            await _repositoryContext.ParticipantImg
                    .AsNoTracking()
                    .Where(a => a.Participant.IdTeamName == constructorId)
                    .Select(a => new ImageDto
                    {
                        Link = a.Image.Link, 
                        Text = a.Participant.Chassis.Name + ", " + a.Participant.Racer.RacerNameEng + " "
                    })
                    .ToArrayAsync();

        public async Task<ConstructorInfoDto> GetInfo(Guid constructorId)
        {
            var query = await _repositoryContext.TeamNames
                .Include(a => a.Image)
                .Include(a => a.ImageLogo)
                .FirstOrDefaultAsync(a => a.Id == constructorId);

            return new ConstructorInfoDto
            {
                Image = query.Image.Link,
                Logo = query.ImageLogo.Link,
                Name = query.Name
            };
        }

        public async Task<IEnumerable<ConstructorSeasonDto>> GetResultBySeason(Guid constructorId)
        {
            var query = await _repositoryContext.Participants
                                .AsNoTracking()
                                .Where(a => a.IdTeamName == constructorId)
                                .OrderBy(a => a.GrandPrix.Season.Year)
                                .Select(a => new
                                {
                                    IdSeason = a.GrandPrix.IdSeason,
                                    Season = a.GrandPrix.Season.Year,
                                    IdChassis = a.Chassis.Id, 
                                    NameChassis = a.Chassis.Name,
                                    Livery = a.Chassis.Livery.Link,

                                    SeasonCllasification = _repositoryContext.SeasonManufacturersClassification
                                        .AsNoTracking()
                                        .Where(b => b.IdTeamName == constructorId && b.IdSeason == a.GrandPrix.IdSeason)
                                        .Select(b => new PositionWithPoints
                                        {
                                            Position = b.Position,
                                            Points = b.Points
                                        })
                                        .FirstOrDefault(),

                                    RacePosition = _repositoryContext.GrandPrixResults
                                                .AsNoTracking()
                                                .Where(b => b.IdParticipant == a.Id)
                                                .Select(b => b.Position)
                                                .Where(b => b != 0)
                                                .OrderBy(b => b)
                                                .FirstOrDefault(),
                                    QuaPosition = _repositoryContext.Qualifications
                                                .AsNoTracking()
                                                .Where(b => b.IdParticipant == a.Id)
                                                .Select(b => b.Position)
                                                .Where(b => b != 0)
                                                .OrderBy(b => b)
                                                .FirstOrDefault(),

                                    FastLap = _repositoryContext.FastLaps
                                                .AsNoTracking()
                                                .Count(b => b.IdParticipant == a.Id)
                                })
                                .ToArrayAsync();

             var result = (from season in query
                    group season by season.IdSeason into g
                    select new ConstructorSeasonDto
                    {
                        IdSeason = g.Key,
                        Season = (from p in g select p.Season).Max(),
                        Chassis = (from p in g
                                   select new RacerTeamsAndChassies
                                   {
                                       IdChassis = p.IdChassis,
                                       Chassis = p.NameChassis
                                   }).Distinct(),
                        Livery = (from p in g
                                  select new RacerTeamsAndChassies
                                  {
                                      Chassis = p.Livery
                                  }).Distinct(),
                        Points = (from p in g select p.SeasonCllasification).Max(p => p?.Points ?? 0),
                        Position = (from p in g select p.SeasonCllasification).Max(p => p?.Position ?? 0),
                        Win = (from p in g select p.RacePosition).Count(a => a == 1),
                        PolePosition = (from p in g select p.QuaPosition).Count(a => a == 1),
                        FastLap = (from p in g select p.FastLap).Count(),
                        TopStart = (from p in g select p.QuaPosition).Where(a => a != 0).Min(a => a.ToString()),
                        TopFinish = (from p in g select p.RacePosition).Where(a => a != null).Min(a => a.ToString())
                    }).ToArray();

            return result;
        }
    }
}
