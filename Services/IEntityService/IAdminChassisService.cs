using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminChassisService
    {
        Task<bool> Create(ChassisCreateDto chassis);
    }
}
