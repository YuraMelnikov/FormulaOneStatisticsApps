using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IChassiRepository
    {
        Task<IEnumerable<Chassis>> GetAllChassisAsync(bool trackChanges);
        Task<Chassis> GetChassiAsync(Guid chassiId, bool trackChanges);
        void CreateChassi(Chassis chassi);
        void DeleteChassi(Chassis chassi);
    }
}
