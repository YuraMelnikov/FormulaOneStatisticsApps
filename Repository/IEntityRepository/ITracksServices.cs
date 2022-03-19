using Repository.DTO;

namespace Repository.IEntityRepository
{
    public interface ITracksServices
    {
        Task<IEnumerable<TracksDto>> GetTracksList();
    }
}