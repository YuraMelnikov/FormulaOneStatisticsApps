using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminGrandPrixService : IAdminCRU<GrandPrixDto>
    {
        Task<bool> Update(GrandPrixUpdateDto entity);
        Task<IEnumerable<GrandPrixClassificationReadDto?>> GetClassificztion(Guid id);
    }
}