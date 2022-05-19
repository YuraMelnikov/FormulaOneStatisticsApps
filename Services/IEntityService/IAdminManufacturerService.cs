using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminManufacturerService
    {
        Task<bool> Create(ManufacturerCreateDto manufacturer);
    }
}