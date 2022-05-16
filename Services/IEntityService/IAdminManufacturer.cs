using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminManufacturer
    {
        Task<bool> Create(ManufacturerDto manufacturer);
    }
}