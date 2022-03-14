using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGPResultRepository 
    {
        Task<IEnumerable<GrandPrixResult>> GetAllGPResultAsync(bool trackChanges);
        Task<GrandPrixResult> GetGPResultAsync(Guid gPResultId, bool trackChanges);
        void CreateGPResult(GrandPrixResult gPResult);
        void DeleteGPResult(GrandPrixResult gPResult);
    }
}
