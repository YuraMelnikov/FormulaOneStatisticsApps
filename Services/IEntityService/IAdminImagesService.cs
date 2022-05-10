using Microsoft.AspNetCore.Http;
using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminImagesService : IAdminCRU<ImageDto>
    {
        Task<bool> Create(ImageCreateDto entity);
        string SaveImageFile(IFormFile file);
        Task<IEnumerable<ImageDto>> GetByIdSeason(Guid idSeason);
        Task<IEnumerable<ImageDto>> GetByIdConstructor(Guid idConstructor);
    }
}
