using Services.DTO;

namespace Services.IEntityService
{
    public interface ISeasonService
    {
        Task<IEnumerable<CalendarSeasonDto>> GetClendar(Guid seasonId);
        Task<IEnumerable<TeamsSeasonDto>> GetTeamsSeason(Guid seasonId);
        Task<IEnumerable<ChampionshipResultDto>> GetChampionshipRacers(Guid seasonId);
        Task<IEnumerable<ChampionshipResultDto>> GetChampionshipTeams(Guid seasonId);



    }
}
