using AutoMapper;
using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;
using Repository.Service;

namespace Repository.EntityRepository
{
    public class RacersService : RepositoryBase<Racer, RacersDto>, IRacersService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public RacersService(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext, mapper)
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