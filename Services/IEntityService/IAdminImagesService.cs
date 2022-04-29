using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminImagesService : IAdminCRU<ImageDto>
    {
        Task<IEnumerable<ImageDto>> GetByIdSeason(Guid idSeason);
    }
}
