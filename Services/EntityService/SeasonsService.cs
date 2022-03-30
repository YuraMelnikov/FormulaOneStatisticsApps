using Entities.Contexts;
using Services.DTO;
using Services.IEntityService;
using Microsoft.EntityFrameworkCore;

namespace Services.EntityService
{
    public class SeasonsService : ISeasonsService
    {
        private readonly RepositoryContext _repositoryContext;

        public SeasonsService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<SeasonsDto>> GetSeasonsList() => 
            await _repositoryContext.Seasons
                .AsNoTracking()
                .Select(a => new SeasonsDto { Id = a.Id, Name = a.Year.ToString(), ImageLink = a.Image.Link })
                .OrderBy(a => a.Name)
                .ToArrayAsync();
    }
}