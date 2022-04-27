using Services.DTO;

namespace Services.IEntityService
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerDto>> GetChassis(Guid manufacturerId);
        Task<IEnumerable<ManufacturerDto>> GetEngines(Guid manufacturerId);
        Task<IEnumerable<ManufacturerDto>> GetTyres(Guid manufacturerId);
    }
}
