using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGPRepository 
    {
        Task<IEnumerable<GrandPrix>> GetAllGPAsync(bool trackChanges);
        Task<GrandPrix> GetGPAsync(Guid gpId, bool trackChanges);
        void CreateGP(GrandPrix gp);
        void DeleteGP(GrandPrix gp);
    }
}
