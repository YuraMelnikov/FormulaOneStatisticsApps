using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class SeasonService : ISeasonService
    {
        private readonly RepositoryContext _repositoryContext;

        public SeasonService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<SeasonCalendarDto>> GetCalendar(Guid seasonId) =>
             await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Where(a => a.Participant.GrandPrix.IdSeason == seasonId && a.Position == 1)
                .Select(a => new SeasonCalendarDto
                {
                    Name = a.Participant.GrandPrix.GrandPrixName.FullName,
                    Date = a.Participant.GrandPrix.Date.ToString().Substring(0, 10),
                    Distance = (decimal)a.Participant.GrandPrix.TrackСonfiguration.Length * a.Participant.GrandPrix.NumberOfLap,
                    IdGrandPrix = a.Participant.IdGrandPrix,
                    IdTrack = a.Participant.GrandPrix.TrackСonfiguration.IdTrack,
                    Lap = a.Participant.GrandPrix.NumberOfLap,
                    TrackName = a.Participant.GrandPrix.TrackСonfiguration.Track.Name,
                    IdWinnerRacer = a.Participant.IdRacer, 
                    IdWinnerTeam = a.Participant.Chassis.Id, 
                    RacerWinner = a.Participant.Racer.RacerNameEng, 
                    TeamWinner = a.Participant.Chassis.Name 
                })
                .OrderBy(a => a.Date)
                .ToArrayAsync();
        
        public async Task<IEnumerable<SeasonParticipientDto>> GetPercipient(Guid seasonId)
        {
            var participients = await _repositoryContext
                .Participants
                .AsNoTracking()
                .Where(a => a.GrandPrix.IdSeason == seasonId)
                .Select(a => new 
                { 
                    a.IdTeam, 
                    a.Team.Name, 
                    a.IdChassis,
                    Chassis = a.Chassis.Name, 
                    a.IdRacer, 
                    a.Racer.RacerNameEng, 
                    a.IdEngine,
                    Engine = a.Engine.Name, 
                    a.IdTyre,
                    Tyre = a.Tyre.Name
                    
                })
                .Distinct()
                .OrderBy(a => a.Name)
                .ToArrayAsync();

            return participients.DistinctBy(a => a.IdTeam)
                .Select(a => new SeasonParticipientDto 
                {
                    IdTeam = a.IdTeam, 
                    Name = a.Name, 
                    Chassis = participients
                                .Where(b => b.IdTeam == a.IdTeam)
                                .DistinctBy(b => b.IdChassis)
                                .Select(b => new LabelItemWhisId
                                {
                                    Id = b.IdChassis, Name = b.Chassis
                                }),
                    Engines = participients
                                .Where(b => b.IdTeam == a.IdTeam)
                                .DistinctBy(b => b.IdEngine)
                                .Select(b => new LabelItemWhisId
                                {
                                    Id = b.IdEngine,
                                    Name = b.Engine
                                }), 
                    Racers = participients
                                .Where(b => b.IdTeam == a.IdTeam)
                                .DistinctBy(b => b.IdRacer)
                                .Select(b => new LabelItemWhisId
                                {
                                    Id = b.IdRacer,
                                    Name = b.RacerNameEng
                                }), 
                    Tyres = participients
                                .Where(b => b.IdTeam == a.IdTeam)
                                .DistinctBy(b => b.IdTyre)
                                .Select(b => new LabelItemWhisId
                                {
                                    Id = b.IdTyre,
                                    Name = b.Tyre
                                })
                });
        }

        public async Task<IEnumerable<SeasonChampionshipDto>> GetChampionshipRacers(Guid seasonId) =>
            await _repositoryContext.SeasonRacersClassification
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Select(a => new SeasonChampionshipDto
                {
                    Id = a.IdRacer,
                    Name = a.Racer.RacerNameEng,
                    Points = a.Points,
                    Position = a.Position, 
                    Result = _repositoryContext.GrandPrixes.AsNoTracking()
                                .Where(b => b.IdSeason == seasonId)
                                .OrderBy(b => b.NumberInSeason)
                                .Select(b => new SeasonChampColumnDto { 
                                    RacePosition = _repositoryContext.GrandPrixResults.AsNoTracking()
                                                                            .Where(c => c.Participant.IdGrandPrix == b.Id && c.Participant.IdRacer == a.IdRacer)
                                                                            .Select(c => new {c.Position, c.Classification})
                                                                            .OrderBy(c => c.Position)
                                                                            .First().Classification
                                })
                                .ToArray()
                })
                .OrderBy(a => a.Position)
                .ToArrayAsync();

        public async Task<IEnumerable<SeasonChampionshipDto>> GetChampionshipTeams(Guid seasonId) =>
            await _repositoryContext.SeasonManufacturersClassification
                                            .AsNoTracking()
                                            .Where(a => a.IdSeason == seasonId)
                                            .Select(a => new SeasonChampionshipDto
                                            {
                                                Id = a.IdTeamName,
                                                Name = a.TeamName.Name,
                                                Points = a.Points,
                                                Position = a.Position,
                                                Result = _repositoryContext.GrandPrixes.AsNoTracking()
                                                            .Where(b => b.IdSeason == seasonId)
                                                            .OrderBy(b => b.NumberInSeason)
                                                            .Select(b => new SeasonChampColumnDto
                                                            {
                                                                RacePosition = string.Concat(_repositoryContext.GrandPrixResults.AsNoTracking()
                                                                                                        .Where(c => c.Participant.IdGrandPrix == b.Id && c.Participant.IdTeamName == a.IdTeamName)
                                                                                                        .OrderBy(c => c.Position)
                                                                                                        .Select(c => c.Classification + " ")
                                                                                                        .ToList()).TrimEnd(' ')
                                                            })
                                                            .ToArray()
                                            })
                                            .OrderBy(a => a.Position)
                                            .ToArrayAsync();
    }
}
