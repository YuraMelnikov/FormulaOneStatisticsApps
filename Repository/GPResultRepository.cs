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
    public class GPResultRepository : RepositoryBase<GrandPrixResult>, IGPResultRepository
    {
        public GPResultRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateGPResult(GrandPrixResult gpResult) =>
            Create(gpResult);

        public void DeleteGPResult(GrandPrixResult gpResult) =>
            Delete(gpResult);

        public async Task<IEnumerable<GrandPrixResult>> GetAllGPResultAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<GrandPrixResult> GetGPResultAsync(Guid gpResultId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(gpResultId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
