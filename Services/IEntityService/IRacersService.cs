using Services.DTO;

namespace Services.IEntityService
{
    public interface IRacersService
    {
        Task<IEnumerable<RacersDto>> GetRacersList();
    }
}
