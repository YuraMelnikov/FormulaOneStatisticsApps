using AutoMapper;
using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;
using Repository.Service;

namespace Repository.EntityRepository
{
    public class ManufacturersService : RepositoryBase<Manufacturer, ManufacturersDto>, IManufacturersService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public ManufacturersService(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext, mapper)
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
