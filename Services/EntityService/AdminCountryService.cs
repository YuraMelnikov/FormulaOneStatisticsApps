using Entities.Contexts;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminCountryService : IAdminCRU<CountryDto>
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminCountryService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public Task<bool> Create(CountryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CountryDto?> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CountryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
