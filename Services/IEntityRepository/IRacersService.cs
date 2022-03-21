using Services.DTO;

namespace Services.IEntityRepository
{
    public interface IRacersService
    {
        Task<IEnumerable<RacersDto>> GetRacersList();
    }
}
