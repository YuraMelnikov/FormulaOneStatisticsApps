using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class GPRepository : RepositoryBase<GrandPrix>, IGPRepository
    {
        public GPRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateGP(GrandPrix gp) =>
            Create(gp);

        public void DeleteGP(GrandPrix gp) =>
            Delete(gp);

        public async Task<IEnumerable<GrandPrix>> GetAllGPAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<GrandPrix> GetGPAsync(Guid gpId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(gpId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
