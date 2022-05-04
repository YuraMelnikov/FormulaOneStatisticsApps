using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminImagesService : IAdminCRU<ImageDto>
    {
        Task<IEnumerable<ImageDto>> GetByIdSeason(Guid idSeason);
        Task<IEnumerable<ImageDto>> GetByIdConstructor(Guid idConstructor);
    }
}
