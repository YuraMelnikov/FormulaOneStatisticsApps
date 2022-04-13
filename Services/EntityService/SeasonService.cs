using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;
using Services.IService;
using Services.Service;
using System.Text;

namespace Services.EntityService
{
    public class SeasonService : ISeasonService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;
        private readonly IServiceManager _manager;

        public SeasonService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
            _manager = new ServiceManager(_repositoryContext, _mapper);
        }

        public async Task<IEnumerable<CalendarSeasonDto>> GetClendar(Guid seasonId)
        {
            var calendar = await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Select(a => new CalendarSeasonDto
                {
                    Date = a.Date.ToString().Substring(0, 10),
                    Distance = (decimal)a.TrackСonfiguration.Length * a.NumberOfLap,
                    IdGrandPrix = a.Id,
                    IdTrack = a.TrackСonfiguration.IdTrack,
                    Lap = a.NumberOfLap,
                    TrackName = a.TrackСonfiguration.Track.Name
                })
                .OrderBy(a => a.Date)
                .ToArrayAsync();

            foreach (var grandPrix in calendar)
            {
                var winner = await _manager.GrandPrixResult.GetWinner(grandPrix.IdGrandPrix);
                _mapper.Map(winner, grandPrix);
            }

            return calendar;
        }

        public async Task<IEnumerable<TeamsSeasonDto>> GetPercipient(Guid seasonId)
        {

            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .GroupBy(a => a.IdTeam)
                .Select(a => new TeamsSeasonDto { IdTeam = a.Key });
            var teams = await query.ToArrayAsync();

            foreach (var team in teams)
            {
                team.Name = _repositoryContext.Teams.Find(team.IdTeam).Name;
                team.Tyres = await GetTyreTeamOnSeason(seasonId, team.IdTeam);
                team.Racers = await GetRacersTeamOnSeason(seasonId, team.IdTeam);
                team.Engines = await GetEngineTeamOnSeason(seasonId, team.IdTeam);
                team.Chassis = await GetChassisTeamOnSeason(seasonId, team.IdTeam);
            }

            return teams.OrderBy(a => a.Name);
        }

        public async Task<IEnumerable<ChampionshipResultDto>> GetChampionshipRacers(Guid seasonId)
        {
            var grandPrixes = await GetGrandPrixes(seasonId);

            var parcipiantsInSeason = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .GroupBy(x => x.IdRacer)
                .Select(a => new ChampionshipResultDto { Id = a.Key });
            var racers = await parcipiantsInSeason.ToArrayAsync();

            foreach (var racer in racers)
            {
                racer.Name = _repositoryContext.Racers.Find(racer.Id).RacerNameEng;
                racer.Result = new List<SeasonChampColumnDto>();

                foreach (var grandPrix in grandPrixes)
                {
                    var result = _repositoryContext.GrandPrixResults
                        .AsNoTracking()
                        .FirstOrDefault(a => a.Participant.IdRacer == racer.Id & a.Participant.IdGrandPrix == grandPrix.Id);
                    if (result is null)
                        racer.Result.Add(new SeasonChampColumnDto { RacePosition = "-" });
                    else
                        racer.Result.Add(new SeasonChampColumnDto { RacePosition = result.Classification });
                }

                var seasonRacersClassification = _repositoryContext.SeasonRacersClassification
                    .FirstOrDefault(a => a.IdRacer == racer.Id && a.IdSeason == seasonId);
                if(seasonRacersClassification != null)
                {
                    racer.Position = seasonRacersClassification.Position.ToString();
                    racer.Points = seasonRacersClassification.Points;
                }
                else
                {
                    racer.Position = "    ";
                    racer.Points = 0;
                }
            }

            return racers.OrderBy(a => a.Position.Length).ThenBy(a => a.Position);
        }

        public async Task<IEnumerable<ChampionshipResultDto>> GetChampionshipTeams(Guid seasonId)
        {
            var grandPrixes = await GetGrandPrixes(seasonId);

            var teamsInSeason = _repositoryContext.SeasonManufacturersClassification
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Select(a => new ChampionshipResultDto { Id = a.IdTeamName, Name = a.TeamName.Name, Points = a.Points, Position = a.Position.ToString() });
            var teams = await teamsInSeason.ToArrayAsync();

            foreach (var team in teams)
            {
                team.Result = new List<SeasonChampColumnDto>();

                foreach (var grandPrix in grandPrixes)
                {
                    var result = await _repositoryContext.GrandPrixResults
                        .AsNoTracking()
                        .Include(a => a.Participant)
                        .Where(a => a.Participant.IdTeamName == team.Id & a.Participant.IdGrandPrix == grandPrix.Id)
                        .ToArrayAsync();
                    if (result.Count() == 0)
                        team.Result.Add(new SeasonChampColumnDto { RacePosition = "-" });
                    else
                    {
                        var recePosition = new StringBuilder();
                        foreach (var res in result)
                            recePosition.Append(res.Classification + "/");
                        team.Result.Add(new SeasonChampColumnDto { RacePosition = recePosition.ToString().Trim('/') });
                    }
                }
            }

            return teams.OrderBy(a => a.Position.Length).ThenBy(a => a.Position);
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetChassisTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdChassis)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var chassies = await query.ToListAsync();

            foreach (var chassi in chassies)
                chassi.Name = _repositoryContext.Chassis.Find(chassi.Id).Name;

            return chassies;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetEngineTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdEngine)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var engines = await query.ToListAsync();

            foreach (var engine in engines)
                engine.Name = _repositoryContext.Engines.Find(engine.Id).Name;

            return engines;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetRacersTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdRacer)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var racers = await query.ToListAsync();

            foreach (var racer in racers)
                racer.Name = _repositoryContext.Racers.Find(racer.Id).RacerNameEng;

            return racers;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetTyreTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdTyre)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var tyres = await query.ToListAsync();

            foreach (var tyre in tyres)
                tyre.Name = _repositoryContext.Tyres.Find(tyre.Id).Name;

            return tyres;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetGrandPrixes(Guid seasonId)
        {
            var granpPrixesInSeason = _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .OrderBy(a => a.NumberInSeason)
                .Select(a => new LabelItemWhisId { Id = a.Id, Name = a.Name });

            return await granpPrixesInSeason.ToArrayAsync();
        }
    }
}
