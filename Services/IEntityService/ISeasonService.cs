using Services.DTO;

namespace Services.IEntityService
{
    public interface ISeasonService
    {
        Task<IEnumerable<SeasonCalendarDto>> GetCalendar(Guid seasonId);
        Task<IEnumerable<SeasonParticipientDto>> GetPercipient(Guid seasonId);
        Task<IEnumerable<SeasonChampionshipDto>> GetChampionshipRacers(Guid seasonId);
        Task<IEnumerable<SeasonChampionshipDto>> GetChampionshipTeams(Guid seasonId);
    }
}
