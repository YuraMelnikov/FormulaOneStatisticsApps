using Entities.Models;
using Repository.DTO;

namespace Repository.IEntityRepository
{
    public interface ISeasonsService
    {
        Task<IEnumerable<SeasonsDto>> GetSeasonsList();
    }
}
