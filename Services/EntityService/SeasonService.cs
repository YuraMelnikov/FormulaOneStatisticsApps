using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;
using Services.IService;
using Services.Service;

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

        public async Task<IEnumerable<CalendarSeasonDto>> GetClendarSeason(Guid seasonId)
        {
            var calendar = await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Select(a => new CalendarSeasonDto { 
                    Date = a.Date, 
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
                team.Chassies = await _manager.TeamSeason.GetChassisTeamOnSeason(seasonId, team.IdTeam);
            }

            return teams;
        }
    }
}
