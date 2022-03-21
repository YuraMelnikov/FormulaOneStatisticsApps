using Services.DTO;

namespace Services.IEntityRepository
{
    public interface ISeasonsService
    {
        Task<IEnumerable<SeasonsDto>> GetSeasonsList();
    }
}
