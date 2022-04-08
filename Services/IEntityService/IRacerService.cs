using Services.DTO;

namespace Services.IEntityService
{
    public interface IRacerService
    {
        Task<IEnumerable<RacerSeasonsDto>> GetResultBySeason(Guid racerId);
    }
}
