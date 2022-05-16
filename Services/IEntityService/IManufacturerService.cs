using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerDto>> Get();
    }
}