using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILeaderLapRepository
    {
        Task<IEnumerable<LeaderLap>> GetAllLeaderLapAsync(bool trackChanges);
        Task<LeaderLap> GetLeaderLapAsync(Guid leaderLapId, bool trackChanges);
        void CreateLeaderLap(LeaderLap leaderLap);
        void DeleteLeaderLap(LeaderLap leaderLap);
    }
}
