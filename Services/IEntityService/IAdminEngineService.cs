using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminEngineService
    {
        Task<bool> Create(EngineCreateDto engine);
    }
}
