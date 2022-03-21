using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;

namespace Repository.EntityRepository
{
    public class RacersService :  IRacersService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public RacersService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RacersDto>> GetRacersList()
        {
            var racersList = await _repositoryContext.Racers
                .AsNoTracking()
                .Include(a => a.Image)
                .OrderBy(a => a.SecondName)
                .ToArrayAsync();
            return _mapper.Map<IEnumerable<RacersDto>>(racersList);
        }
    }
}