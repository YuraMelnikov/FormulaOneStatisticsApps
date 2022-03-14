using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRacerRepository
    {
        Task<IEnumerable<Racer>> GetAllRacerAsync(bool trackChanges);
        Task<Racer> GetRacerAsync(Guid racerId, bool trackChanges);
        void CreateRacer(Racer racer);
        void DeleteRacer(Racer racer);
    }
}
