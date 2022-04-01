using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface ISeasonService
    {
        Task<IEnumerable<CalendarSeasonDto>> GetClendar(Guid seasonId);
        Task<IEnumerable<TeamsSeasonDto>> GetPercipient(Guid seasonId);
        Task<IEnumerable<ChampionshipResultDto>> GetChampionshipRacers(Guid seasonId);
        Task<IEnumerable<ChampionshipResultDto>> GetChampionshipTeams(Guid seasonId);
        Task<IEnumerable<LabelItemWhisId>> GetRacersTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetTyreTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetChassisTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetEngineTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetGrandPrixes(Guid seasonId);
    }
}
