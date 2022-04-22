using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ConstructorsService : IConstructorsService
    {
        private readonly RepositoryContext _repositoryContext;

        public ConstructorsService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<CardItemDto>> GetConstructorsList() => 
            await _repositoryContext.TeamNames
                    .AsNoTracking()
                    .Include(a => a.Image)
                    .Select(a => new CardItemDto
                    {
                        Name = a.Name,
                        Id = a.Id,
                        ImageLink = a.Image.Link
                    })
                    .OrderBy(a => a.Name)
                    .ToArrayAsync();
    }
}
