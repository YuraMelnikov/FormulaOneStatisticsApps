using Services.DTO;

namespace Services.IEntityService
{
    public interface IManufacturersService
    {
        Task<IEnumerable<ManufacturersDto>> GetManufacturersList();
    }
}
