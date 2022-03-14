using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFastLapRepository 
    {
        Task<IEnumerable<FastLap>> GetAllFastLapAsync(bool trackChanges);
        Task<FastLap> GetFastLapAsync(Guid fastLapId, bool trackChanges);
        void CreateFastLap(FastLap fastLap);
        void DeleteFastLap(FastLap fastLap);
    }
}
