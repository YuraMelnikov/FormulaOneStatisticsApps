using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminImagesService : IAdminImagesService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminImagesService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ImageDto entity)
        {
            if (_repositoryContext.Images.AsNoTracking().Count(a => a.Link == entity.Link) > 0)
                return false;

            var newImage = new Image
            {
                Link = entity.Link
            };
            _repositoryContext.Add(newImage);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ImageDto>> Get() =>
            await _repositoryContext.Images
                .AsNoTracking()
                .Select(a => new ImageDto
                {
                    Id = a.Id,
                    Link = a.Link
                })
                .ToArrayAsync();

        public async Task<ImageDto?> GetById(Guid Id) =>
             await _repositoryContext.Images
                .AsNoTracking()
                .Where(a => a.Id == Id)
                .Select(a => new ImageDto
                {
                    Id = a.Id,
                    Link = a.Link
                })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ImageDto>> GetByIdSeason(Guid idSeason) =>
            await _repositoryContext.SeasonImg
                .AsNoTracking()
                .Where(a => a.IdSeason == idSeason)
                .Select(a => new ImageDto
                {
                    Id = a.Image.Id,
                    Link = a.Image.Link
                })
                .ToArrayAsync();

        public async Task<bool> Update(ImageDto entity)
        {
            var image = await _repositoryContext.Images
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (image is null)
                return false;

            image.Link = entity.Link;
            _repositoryContext.Update(image);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
