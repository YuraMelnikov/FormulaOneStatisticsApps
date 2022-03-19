using Repository.DTO;

namespace Repository.IEntityRepository
{
    public interface IManufacturersService
    {
        Task<IEnumerable<ManufacturersDto>> GetManufacturersList();
    }
}
