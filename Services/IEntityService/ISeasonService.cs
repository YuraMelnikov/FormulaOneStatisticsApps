using Services.DTO;

namespace Services.IEntityService
{
    public interface ISeasonService
    {
        Task<IEnumerable<CalendarSeasonDto>> GetClendarSeason(Guid seasonId);
    }
}
