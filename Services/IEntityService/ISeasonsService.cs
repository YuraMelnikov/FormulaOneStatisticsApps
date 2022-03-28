using Services.DTO;

namespace Services.IEntityService
{
    public interface ISeasonsService
    {
        Task<IEnumerable<SeasonsDto>> GetSeasonsList();
    }
}
