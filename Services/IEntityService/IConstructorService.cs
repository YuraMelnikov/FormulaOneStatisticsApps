using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IConstructorService
    {
        Task<IEnumerable<ConstructorSeasonDto>> GetResultBySeason(Guid constructorId);
        Task<IEnumerable<ConstructorChampionshipDto>> GetClassification(Guid constructorId);
        Task<ConstructorInfoDto> GetInfo(Guid constructorId);
        Task<IEnumerable<ImageDto>> GetImages(Guid constructorId);
    }
}
