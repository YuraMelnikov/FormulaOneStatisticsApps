using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITeamRepository 
    {
        Task<IEnumerable<Team>> GetAllTeamAsync(bool trackChanges);
        Task<Team> GetTeamAsync(Guid teamId, bool trackChanges);
        void CreateTeam(Team team);
        void DeleteTeam(Team team);
    }
}
