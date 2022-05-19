using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminTeamNameService : IAdminTeamNameService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminTeamNameService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(TeamNameCreateDto teamName)
        {
            if (_repositoryContext.TeamNames.Count(a => a.Name == teamName.Name) > 0)
                return false;

            var newTeamName = new TeamName
            {
                Name = teamName.Name, 
                IdCountry = teamName.IdCountry, 
                TimeApiId  = teamName.TimeApiId, 
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id,
                IdImageLogo = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id
            };
            _repositoryContext.Add(newTeamName);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
