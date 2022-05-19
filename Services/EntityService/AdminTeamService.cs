using Entities.Contexts;
using Entities.Models;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminTeamService : IAdminTeamService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminTeamService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(TeamCreateDto team)
        {
            if (_repositoryContext.Teams.Count(a => a.Name == team.Name) > 0)
                return false;

            var newTeam = new Team
            {
                Name = team.Name
            };
            _repositoryContext.Add(newTeam);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
