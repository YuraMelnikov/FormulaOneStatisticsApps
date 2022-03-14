using Entities.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts
{
    public interface ITyreRepository
    {
        Task<IEnumerable<Tyre>> GetAllTyreAsync(bool trackChanges);
        Task<Tyre> GetTyreAsync(Guid tyreId, bool trackChanges);
        void CreateTyre(Tyre tyre);
        void DeleteTyre(Tyre tyre);
    }
}
