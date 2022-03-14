using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class TeamNameRepository : RepositoryBase<TeamName>, ITeamNameRepository
    {
        public TeamNameRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTeamName(TeamName teamName) =>
            Create(teamName);

        public void DeleteTeamName(TeamName teamName) =>
            Delete(teamName);

        public async Task<IEnumerable<TeamName>> GetAllTeamNameAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.FullName)
            .ToListAsync();

        public async Task<TeamName> GetTeamNameAsync(Guid teamNameId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(teamNameId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
