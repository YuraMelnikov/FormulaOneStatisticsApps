using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IConstructorsService
    {
        Task<IEnumerable<CardItemDto>> GetConstructorsList();
    }
}