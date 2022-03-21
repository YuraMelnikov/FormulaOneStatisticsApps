using Services.DTO;

namespace Services.IEntityRepository
{
    public interface IManufacturersService
    {
        Task<IEnumerable<ManufacturersDto>> GetManufacturersList();
    }
}
