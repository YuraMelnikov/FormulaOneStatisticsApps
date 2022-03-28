using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
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
