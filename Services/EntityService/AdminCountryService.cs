using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminCountryService : IAdminCRU<CountryDto>
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminCountryService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(CountryDto entity)
        {
            var image = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == DefaulValues.DefaultImage);

            if (image is null)
                return false;

            Country country = new Country
            {
                IdImage = image.Id, 
                Name = entity.Name, 
                NameRu = entity.Name
            };
            _repositoryContext.Add(country);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid entity)
        {
            var country = await _repositoryContext.Countries.FindAsync(entity);
            if (country is null)
                return false;

            _repositoryContext.Remove(country);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CountryDto>> Get() =>
            await _repositoryContext.Countries
                .AsNoTracking()
                .Select(a => new CountryDto
                {
                    Id = a.Id, 
                    Name = a.Name
                })
                .OrderBy(a => a.Name)
                .ToArrayAsync();

        public async Task<CountryDto?> GetById(Guid Id)
        {
            var query = await _repositoryContext.Countries.FindAsync(Id);
            if (query is null)
                return null;
            return new CountryDto { Id = query.Id, Name = query.Name };
        }

        public async Task<bool> Update(CountryDto entity)
        {
            var image = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == entity.Name);
            if (image is null)
                return false;

            var country = await _repositoryContext.Countries.FindAsync(entity.Id);
            if (country is null)
                return false;

            country.IdImage = image.Id;
            _repositoryContext.Update(country);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
