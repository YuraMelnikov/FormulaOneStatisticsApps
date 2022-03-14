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
    public class FastLapRepository : RepositoryBase<FastLap>, IFastLapRepository
    {
        public FastLapRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateFastLap(FastLap fastLap) =>
            Create(fastLap);

        public void DeleteFastLap(FastLap fastLap) =>
            Delete(fastLap);

        public async Task<IEnumerable<FastLap>> GetAllFastLapAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<FastLap> GetFastLapAsync(Guid fastLapId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(fastLapId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
