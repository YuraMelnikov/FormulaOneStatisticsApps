using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly RepositoryContext _repositoryContext;

        public ManufacturerService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<ManufacturerDto>> GetChassis(Guid manufacturerId)
        {


            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManufacturerDto>> GetEngines(Guid manufacturerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManufacturerDto>> GetTyres(Guid manufacturerId)
        {
            throw new NotImplementedException();
        }
    }
}
