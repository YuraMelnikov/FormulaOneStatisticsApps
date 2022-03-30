using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ManufacturersService : IManufacturersService
    {
        private readonly RepositoryContext _repositoryContext;

        public ManufacturersService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<ManufacturersDto>> GetManufacturersList() =>
            await _repositoryContext.Manufacturers
                .AsNoTracking()
                .Select(a => new ManufacturersDto { Id = a.Id, Name = a.Name, ImageLink = a.Image.Link })
                .OrderBy(a => a.Name)
                .ToArrayAsync();
    }
}
