using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISeasonRepository
    {
        Task<IEnumerable<Season>> GetAllSeasonAsync(bool trackChanges);
        Task<Season> GetSeasonAsync(Guid seasonId, bool trackChanges);
        void CreateSeason(Season season);
        void DeleteSeason(Season season);
    }
}
