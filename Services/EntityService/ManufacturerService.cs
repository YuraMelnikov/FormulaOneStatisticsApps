using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly RepositoryContext _repositoryContext;

        public ManufacturerService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<ManufacturerDto>> Get() =>
            await _repositoryContext.Manufacturers
                .AsNoTracking()
                .Select(a => new ManufacturerDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    IdCountry = a.IdCountry
                })
                .OrderBy(a => a.Name)
                .ToArrayAsync();
    }
}
