using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ChassisService : IChassisService
    {
        private readonly RepositoryContext _repositoryContext;

        public ChassisService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<ChassisResultsDto>> GetClassification(Guid chassisId)
        {
            var query = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Where(a => a.Participant.IdRacer == chassisId)
                .OrderBy(a => a.Participant.GrandPrix.Number)
                .Select(a => new
                {
                    Id = a.Participant.IdGrandPrix,
                    Name = a.Participant.GrandPrix.GrandPrixName.ShortName,
                    Classification = a.Classification,
                    Season = a.Participant.GrandPrix.Season.Year
                })
                .ToArrayAsync();

            var result = (from season in query
                          group season by season.Season into g
                          select new ChassisResultsDto
                          {
                              Season = g.Key,

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

        public async Task<IEnumerable<ImageDto>> GetImages(Guid chassisId) =>
            await _repositoryContext.ParticipantImg
                .AsNoTracking()
                .Where(a => a.Participant.IdChassis == chassisId)
                .Select(a => new ImageDto
                {
                    Link = a.Image.Link,
                    Text = a.Participant.Racer.RacerNameEng
                })
                .ToArrayAsync();

        public async Task<ChassisInfoDto> GetInfo(Guid chassisId) =>
            await _repositoryContext.Chassis
                .AsNoTracking()
                .Where(a => a.Id == chassisId)
                .Select(a => new ChassisInfoDto
                {
                    Name = a.Name,
                    Image = a.Image.Link,
                    Livery = a.Livery.Link,
                    Points = _repositoryContext.GrandPrixResults
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId)
                                    .Sum(a => a.Points),
                    Win = _repositoryContext.GrandPrixResults
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId && a.Position == 1)
                                    .Count(),
                    PolePosition = _repositoryContext.Qualifications
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId && a.Position == 1)
                                    .Count(),
                    FastLap = _repositoryContext.FastLaps
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId)
                                    .Count(),
                    TopStart = _repositoryContext.Qualifications
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId)
                                    .Min(a => a.Position),
                    TopFinish = _repositoryContext.GrandPrixResults
                                    .AsNoTracking()
                                    .Where(a => a.Participant.IdChassis == chassisId)
                                    .Min(a => a.Classification)
                })
                .FirstOrDefaultAsync();

        public async Task<ChassisListDto> GetList(Guid chassisId)
        {
            var query = await _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdChassis == chassisId)
                .OrderBy(a => a.GrandPrix.Season.Year)
                .Select(a => new
                {
                    IdSeason = a.GrandPrix.IdSeason,
                    Season = a.GrandPrix.Season.Year,
                    Team = a.Team.Name,
                    IdDriver = a.IdRacer,
                    Driver = a.Racer.RacerNameEng,
                    IdEngine = a.IdEngine,
                    Engine = a.Engine.Name,
                    IdTyre = a.IdTyre,
                    Tyre = a.Tyre.Name
                })
                .Distinct()
                .ToArrayAsync();

            var result = new ChassisListDto
            {
                Seasons = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdSeason, 
                    Name = a.Season.ToString()
                }).Distinct(),
                Drivers = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdDriver,
                    Name = a.Driver
                }).Distinct(),
                Engines = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdEngine,
                    Name = a.Engine
                }).Distinct(),
                Tyres = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdTyre,
                    Name = a.Tyre
                }).Distinct(),
            };

            return result;
        }
    }
}
