using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminTeamService
    {
        Task<bool> Create(TeamCreateDto team);
    }
}