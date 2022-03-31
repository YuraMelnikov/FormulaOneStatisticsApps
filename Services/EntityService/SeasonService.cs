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

        public async Task<IEnumerable<ChampionshipResultDto>> GetChampionshipRacers(Guid seasonId)
        {
            var granpPrixesInSeason = _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .OrderBy(a => a.NumberInSeason)
                .Select(a => new LabelItemWhisId { Id = a.Id, Name = a.Name });
            var grandPrixes = await granpPrixesInSeason.ToArrayAsync();

            var parcipiantsInSeason = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .GroupBy(x => x.IdRacer)
                .Select(a => new ChampionshipResultDto { Id = a.Key } );
            var racers = await parcipiantsInSeason.ToArrayAsync();

            foreach(var racer in racers)
            {
                racer.Name = _repositoryContext.Racers.Find(racer.Id).SecondName;
                racer.Result = new List<SeasonChampColumnDto>();
                foreach(var grandPrix in grandPrixes)
                {
                    var result = _repositoryContext.GrandPrixResults
                        .AsNoTracking()
                        .FirstOrDefault(a => a.Participant.IdRacer == racer.Id & a.Participant.IdGrandPrix == grandPrix.Id);
                    if(result is null)
                        racer.Result.Add(new SeasonChampColumnDto { RacePosition = "-"});
                    else
                        racer.Result.Add(new SeasonChampColumnDto { RacePosition = result.Classification });
                }
                racer.Points = _repositoryContext.GrandPrixResults
                    .AsNoTracking()
                    .Where(a => a.Participant.IdRacer == racer.Id & a.Participant.GrandPrix.IdSeason == seasonId)
                    .Sum(a => a.Points);
            }

            return racers;
        }

        public async Task<IEnumerable<ChampionshipResultDto>> GetChampionshipTeams(Guid seasonId)
        {
            var granpPrixesInSeason = _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .OrderBy(a => a.NumberInSeason)
                .Select(a => new LabelItemWhisId { Id = a.Id, Name = a.Name });
            var grandPrixes = await granpPrixesInSeason.ToArrayAsync();

            var teamsInSeason = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .GroupBy(x => x.Chassis.IdManufacturer)
                .Select(a => new ChampionshipResultDto { Id = a.Key });
            var teams = await teamsInSeason.ToArrayAsync();

            foreach (var team in teams)
            {
                team.Name = _repositoryContext.Manufacturers.Find(team.Id).Name;
                team.Result = new List<SeasonChampColumnDto>();
                foreach (var grandPrix in grandPrixes)
                {
                    var result = await _repositoryContext.GrandPrixResults
                        .AsNoTracking()
                        .Where(a => a.Participant.Chassis.IdManufacturer == team.Id & a.Participant.IdGrandPrix == grandPrix.Id)
                        .ToArrayAsync();
                    if (result is null)
                        team.Result.Add(new SeasonChampColumnDto { RacePosition = "-" });
                    else
                    {
                        var recePosition = new StringBuilder();
                        foreach(var res in result)
                            recePosition.Append(res.Classification + " /");
                        team.Result.Add(new SeasonChampColumnDto { RacePosition = recePosition.ToString() });
                    }
                        
                }
                team.Points = _repositoryContext.GrandPrixResults
                    .AsNoTracking()
                    .Where(a => a.Participant.Chassis.IdManufacturer == team.Id & a.Participant.GrandPrix.IdSeason == seasonId)
                    .Sum(a => a.Points);
            }

            return teams;
        }

        public async Task<IEnumerable<CalendarSeasonDto>> GetClendarSeason(Guid seasonId)
        {
            var calendar = await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Select(a => new CalendarSeasonDto { 
                    Date = a.Date.ToString().Substring(0, 10),
                    Distance = (decimal)a.TrackСonfiguration.Length * a.NumberOfLap, 
                    IdGrandPrix = a.Id, 
                    IdTrack = a.TrackСonfiguration.IdTrack, 
                    Lap = a.NumberOfLap, 
                    TrackName = a.TrackСonfiguration.Track.Name 
                })
                .OrderBy(a => a.Date)
                .ToArrayAsync();
            
            foreach(var grandPrix in calendar)
            {
                var winner = await _manager.GrandPrixResult.GetWinner(grandPrix.IdGrandPrix);
                _mapper.Map(winner, grandPrix);
            }

            return calendar;
        }

        public async Task<IEnumerable<TeamsSeasonDto>> GetTeamsSeason(Guid seasonId)
        {

            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .GroupBy(a => a.IdTeam)
                .Select(a => new TeamsSeasonDto { IdTeam = a.Key });
            var teams = await query.ToListAsync();

            foreach (var team in teams)
            {
                team.Name = _repositoryContext.Teams.Find(team.IdTeam).Name;
                team.Tyres = await _manager.TeamSeason.GetTyreTeamOnSeason(seasonId, team.IdTeam);
                team.Racers = await _manager.TeamSeason.GetRacersTeamOnSeason(seasonId, team.IdTeam);
                team.Engines = await _manager.TeamSeason.GetEngineTeamOnSeason(seasonId, team.IdTeam);
                team.Chassis = await _manager.TeamSeason.GetChassisTeamOnSeason(seasonId, team.IdTeam);
            }

            return teams;
        }
    }
}
