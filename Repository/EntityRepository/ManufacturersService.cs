using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;

namespace Repository.EntityRepository
{
    public class ManufacturersService : IManufacturersService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public ManufacturersService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManufacturersDto>> GetManufacturersList()
        {
            var manufacturersList = await _repositoryContext.Manufacturers
                .AsNoTracking()
                .Include(a => a.Image)
                .OrderBy(a => a.Name)
                .ToArrayAsync();
            return _mapper.Map<IEnumerable<ManufacturersDto>>(manufacturersList);
        }
    }
}
