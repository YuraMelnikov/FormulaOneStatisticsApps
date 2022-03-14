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
    public class LeaderLapRepository : RepositoryBase<LeaderLap>, ILeaderLapRepository
    {
        public LeaderLapRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateLeaderLap(LeaderLap leaderLap) =>
            Create(leaderLap);

        public void DeleteLeaderLap(LeaderLap leaderLap) =>
            Delete(leaderLap);

        public async Task<IEnumerable<LeaderLap>> GetAllLeaderLapAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<LeaderLap> GetLeaderLapAsync(Guid leaderLapId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(leaderLapId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
