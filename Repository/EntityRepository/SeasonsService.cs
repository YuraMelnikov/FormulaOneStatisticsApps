using AutoMapper;
using Entities.Contexts;
using Repository.DTO;
using Repository.IEntityRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepository
{
    public class SeasonsService : ISeasonsService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public SeasonsService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeasonsDto>> GetSeasonsList()
        {
            var sesonsList = await _repositoryContext.Seasons
                .AsNoTracking()
                .Include(a => a.Image)
                .OrderBy(a => a.Year)
                .ToArrayAsync();
            return _mapper.Map<IEnumerable<SeasonsDto>>(sesonsList);
        }
    }
}