using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminGrandPrixResultService
    {
        Task<GrandPrixResultDto> Get(Guid id);
        Task<bool> Update(GrandPrixResultDto result);
    }
}
