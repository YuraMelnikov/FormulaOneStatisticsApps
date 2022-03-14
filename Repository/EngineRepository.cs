using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EngineRepository : RepositoryBase<Engine>, IEngineRepository
    {
        public EngineRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateEngine(Engine engine) =>
            Create(engine);

        public void DeleteEngine(Engine engine) =>
            Delete(engine);

        public async Task<IEnumerable<Engine>> GetAllEngineAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Engine> GetEngineAsync(Guid engineId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(engineId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
