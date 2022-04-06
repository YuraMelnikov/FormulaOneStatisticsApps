using Services.DTO;

namespace Services.IEntityService
{
    public interface IRacerService
    {
        Task<IEnumerable<RacerResultsByYears>> GetResultBySeason(Guid racerId);
    }
}
