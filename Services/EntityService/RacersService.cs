using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class RacersService :  IRacersService
    {
        private readonly RepositoryContext _repositoryContext;

        public RacersService(RepositoryContext repositoryContext) => 
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<RacersDto>> GetRacersList() =>
            await _repositoryContext.Racers
                .AsNoTracking()
                .Select(a => new RacersDto { Id = a.Id, Name = a.FirstName + " " + a.SecondName, ImageLink = a.Image.Link })
                .OrderBy(a => a.Name)
                .ToArrayAsync();
    }
}