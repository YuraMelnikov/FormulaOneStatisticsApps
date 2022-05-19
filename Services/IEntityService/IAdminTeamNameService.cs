using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminTeamNameService
    {
        Task<bool> Create(TeamNameCreateDto teamName);
    }
}