using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IChassisService
    {
        Task<ChassisListDto> GetList(Guid chassisId);
        Task<IEnumerable<ChassisResultsDto>> GetClassification(Guid chassisId);
        Task<ChassisInfoDto> GetInfo(Guid chassisId);
        Task<IEnumerable<ImageDto>> GetImages(Guid chassisId);
    }
}
