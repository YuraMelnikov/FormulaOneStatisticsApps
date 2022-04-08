using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class RacerService : IRacerService
    {
        private readonly RepositoryContext _repositoryContext;

        public RacerService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<RacerSeasonsDto>> GetResultBySeason(Guid racerId)
        {
            var seasons = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdRacer == racerId)
                .GroupBy(a => a.GrandPrix.IdSeason)
                .Select(a => new RacerSeasonsDto { IdSeason = a.Key });
            var resultsBySeason = await seasons.ToArrayAsync();

            foreach(var result in resultsBySeason)
            {
                result.Season = _repositoryContext.Seasons.Find(result.IdSeason).Year;
                var chassies = _repositoryContext.Participants
                    .AsNoTracking()
                    .Where(a => a.IdRacer == racerId && a.GrandPrix.IdSeason == result.IdSeason)
                    .GroupBy(a => a.IdChassis)
                    .Select(a => a.Key);
                var chassiesList = await chassies.ToArrayAsync();
                var listRacerTeamsAndChassies = new List<RacerTeamsAndChassies>();
                foreach (var ch in chassiesList)
                {
                    var newCh = _repositoryContext.Chassis
                        .Include(a => a.Livery)
                        .FirstOrDefault(a => a.Id == ch);
                    listRacerTeamsAndChassies.Add(new RacerTeamsAndChassies { IdChassies = newCh.Id, Chassies = newCh.Name, LiveryLink = newCh.Livery.Link });
                }
                result.Chassies = listRacerTeamsAndChassies;
                var seasonResult = _repositoryContext.SeasonRacersClassification
                    .AsNoTracking()
                    .FirstOrDefault(a => a.IdSeason == result.IdSeason && a.IdRacer == racerId);
                result.Positions = seasonResult.Position.ToString();
                result.Points = seasonResult.Points.ToString();
                var gpResults = await _repositoryContext.GrandPrixResults
                    .AsNoTracking()
                    .Where(a => a.Participant.GrandPrix.IdSeason == result.IdSeason && a.Participant.IdRacer == racerId)
                    .ToArrayAsync();
                result.Win = gpResults.Count(a => a.Position == 1);
                result.PolePosition = _repositoryContext.Qualifications
                    .AsNoTracking()
                    .Where(a => a.Participant.GrandPrix.IdSeason == result.IdSeason && a.Participant.IdRacer == racerId)
                    .Count(a => a.Position == 1);
                result.FastLap = _repositoryContext.FastLaps
                    .AsNoTracking()
                    .Count(a => a.Participant.GrandPrix.IdSeason == result.IdSeason && a.Participant.IdRacer == racerId);
                result.TopFinish = gpResults.Min(a => a.Position).ToString();
                result.GrandPrixes = _repositoryContext.Participants
                    .AsNoTracking()
                    .Count(a => a.GrandPrix.IdSeason == result.IdSeason && a.IdRacer == racerId);
            }

            return resultsBySeason.OrderBy(a => a.Season);
        }
    }
}
