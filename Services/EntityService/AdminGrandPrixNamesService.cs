using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminGrandPrixNamesService : IAdminGrandPrixNamesService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminGrandPrixNamesService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(GrandPrixNamesCreateDto name)
        {
            if (_repositoryContext.GrandPrixNames.AsNoTracking().Count(a => a.FullName == name.FullName) > 0)
                return false;

            var newName = new GrandPrixNames
            {
                FullName = name.FullName, 
                ShortName = name.ShortName
            };
            _repositoryContext.Add(newName);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}