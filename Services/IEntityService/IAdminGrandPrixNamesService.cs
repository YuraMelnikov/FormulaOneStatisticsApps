using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminGrandPrixNamesService
    {
        Task<bool> Create(GrandPrixNamesCreateDto name);
    }
}
