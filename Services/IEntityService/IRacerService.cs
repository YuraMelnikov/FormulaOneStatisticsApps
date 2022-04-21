using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IRacerService
    {
        Task<IEnumerable<RacerSeasonsDto>> GetResultBySeason(Guid racerId);
        Task<IEnumerable<ImageDto>> GetImages(Guid racerId);
        Task<RacerInfoDto> GetInfo(Guid racerId);
        Task<IEnumerable<SeasonChampionshipDto>> GetClassifications(Guid racerId);
    }
}
