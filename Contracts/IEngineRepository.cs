using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEngineRepository 
    {
        Task<IEnumerable<Engine>> GetAllEngineAsync(bool trackChanges);
        Task<Engine> GetEngineAsync(Guid engineId, bool trackChanges);
        void CreateEngine(Engine engine);
        void DeleteEngine(Engine engine);
    }
}
