using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class RacerService : IRacerService
    {
        private readonly RepositoryContext _repositoryContext;

        public RacerService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<RacerChampionshipDto>> GetClassifications(Guid racerId)
        {
            var query = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Where(a => a.Participant.IdRacer == racerId)
                .OrderBy(a => a.Participant.GrandPrix.Number)
                .Select(a => new 
                {
                    Id = a.Participant.IdGrandPrix, 
                    Name = a.Participant.GrandPrix.GrandPrixName.ShortName, 
                    Classification = a.Classification,
                    Season = a.Participant.GrandPrix.Season.Year,
                    SeasonCllasification = _repositoryContext.SeasonRacersClassification
                        .AsNoTracking()
                        .Where(b => b.IdRacer == racerId && b.IdSeason == a.Participant.GrandPrix.IdSeason)
                        .Select(b => new
                        {
                            b.Position,
                            b.Points
                        }).FirstOrDefault(),
                })
                .ToArrayAsync();

            return (from season in query
                    group season by season.Season into g
                    select new RacerChampionshipDto
                    {
                        Season = g.Key,

                        Points = (from p in g select p.SeasonCllasification.Points).Max(),
                        Position = (from p in g select p.SeasonCllasification.Position).Max(),

                        Result = (from p in g
                                  select new RacerChampColumnDto
                                  {
                                      Id = p.Id,
                                      RacePosition = p.Classification,
                                      Name = p.Name
                                  })
                    }).ToArray();
        }

        public async Task<IEnumerable<ImageDto>> GetImages(Guid racerId) =>
            await _repositoryContext.RacerImgs
                .AsNoTracking()
                .Where(a => a.IdRacer == racerId)
                .Select(a => new ImageDto
                {
                    Link = a.Image.Link
                })
                .ToArrayAsync();

        public async Task<RacerInfoDto> GetInfo(Guid racerId)
        {
            var racer = await _repositoryContext.Racers
                .Include(a => a.Image)
                .FirstOrDefaultAsync(a => a.Id == racerId);
            return new RacerInfoDto
            {
                Name = racer.RacerNameEng, 
                BirthDay = racer.Born.ToShortDateString(),
                ImgLink = racer.Image.Link
            };
        }

        public async Task<IEnumerable<RacerSeasonsDto>> GetResultBySeason(Guid racerId)
        {
            var query = await _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdRacer == racerId)
                .OrderBy(a => a.GrandPrix.Season.Year)
                .Select(a => new
                {
                    IdSeason = a.GrandPrix.IdSeason,
                    Season = a.GrandPrix.Season.Year,
                    IdChassis = a.Chassis.Id,
                    NameChassis = a.Chassis.Name,
                    SeasonCllasification = _repositoryContext.SeasonRacersClassification
                        .AsNoTracking()
                        .Where(b => b.IdRacer == racerId && b.IdSeason == a.GrandPrix.IdSeason)
                        .Select(b => new
                        {
                            b.Position,
                            b.Points
                        }).FirstOrDefault(),
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

            return (from season in query
                            group season by season.IdSeason into g
                            select new RacerSeasonsDto
                            {
                                IdSeason = g.Key,
                                Season = (from p in g select p.Season).Max(),
                                Chassis = (from p in g
                                           select new RacerTeamsAndChassies
                                           {
                                               IdChassis = p.IdChassis,
                                               Chassis = p.NameChassis
                                           }).Distinct(),
                                Points = (from p in g select p.SeasonCllasification.Points).Max(),
                                Position = (from p in g select p.SeasonCllasification.Position).Max(),
                                Win = (from p in g select p.RacePosition).Count(a => a == 1),
                                PolePosition = (from p in g select p.QuaPosition).Count(a => a == 1),
                                FastLap = (from p in g select p.FastLap).Count(),
                                TopStart = (from p in g select p.QuaPosition).Where(a => a != 0).Min(a => a.ToString()),
                                TopFinish = (from p in g select p.RacePosition).Where(a => a != null).Min(a => a.ToString()),
                                GrandPrixes = (from p in g select p.RacePosition).Count()
                            }).ToArray();
        }
    }
}
