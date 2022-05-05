using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminConstructorService : IAdminCRU<ConstructorDto>
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminConstructorService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ConstructorDto entity)
        {
            if (_repositoryContext.TeamNames.AsNoTracking().Count(a => a.Name == entity.Name) > 0)
                return false;

            var newImage = await _repositoryContext.Images
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(a => a.Link == DefaulValues.DefaultImage);
            if (newImage is null)
                return false;

            var newConstructor = new TeamName
            {
                IdCountry = entity.IdCountry, 
                IdImage = newImage.Id, 
                IdImageLogo = newImage.Id, 
                Name = entity.Name, 
                TimeApiId = ""
            };
            _repositoryContext.Add(newConstructor);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var team = await _repositoryContext.TeamNames.FindAsync(id);

            if (team is null)
                return false;

            _repositoryContext.Remove(team);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ConstructorDto>> Get() =>
            await _repositoryContext.TeamNames
                .AsNoTracking()
                .Select(a => new ConstructorDto
                {
                    Id = a.Id, 
                    IdCountry = a.IdCountry, 
                    Logo = a.ImageLogo.Link, 
                    Country = a.Country.Name, 
                    Name = a.Name, 
                    Image = a.Image.Link
                })
                .OrderBy(a => a.Name)
                .ToArrayAsync();

        public async Task<ConstructorDto?> GetById(Guid Id) =>
             await _repositoryContext.TeamNames
                .AsNoTracking()
                .Where(a => a.Id == Id)
                .Select(a => new ConstructorDto
                {
                    Id = a.Id,
                    IdCountry = a.IdCountry,
                    Logo = a.ImageLogo.Link,
                    Country = a.Country.Name,
                    Name = a.Name,
                    Image = a.Image.Link
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Update(ConstructorDto entity)
        {
            var constructor = await _repositoryContext.TeamNames
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (constructor is null)
                return false;

            var newImage = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == entity.Image);
            if (newImage is null)
                return false;

            var newLogo = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == entity.Logo);
            if (newLogo is null)
                return false;

            constructor.IdImage = newImage.Id;
            constructor.IdImageLogo = newLogo.Id;
            _repositoryContext.Update(constructor);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
