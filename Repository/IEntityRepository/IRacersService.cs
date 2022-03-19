using Repository.DTO;

namespace Repository.IEntityRepository
{
    public interface IRacersService
    {
        Task<IEnumerable<RacersDto>> GetRacersList();
    }
}
