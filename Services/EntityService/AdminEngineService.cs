using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminEngineService : IAdminEngineService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminEngineService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(EngineCreateDto engine)
        {
            if (_repositoryContext.Engines.Count(a => a.Name == engine.Name) > 0)
                return false;

            var newEngine = new Engine
            {
                IdManufacturer = engine.IdManufacturer,
                Name = engine.Name,
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id
            };
            _repositoryContext.Add(newEngine);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}