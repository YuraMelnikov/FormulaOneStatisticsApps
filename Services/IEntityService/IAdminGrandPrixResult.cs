using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminGrandPrixResult
    {
        Task<GrandPrixResultDto> Get(Guid id);
        Task<bool> Update(GrandPrixResultDto result);
    }
}
