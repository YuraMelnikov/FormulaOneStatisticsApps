using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITeamNameRepository
    {
        Task<IEnumerable<TeamName>> GetAllTeamNameAsync(bool trackChanges);
        Task<TeamName> GetTeamNameAsync(Guid teamNameId, bool trackChanges);
        void CreateTeamName(TeamName teamName);
        void DeleteTeamName(TeamName teamName);
    }
}
