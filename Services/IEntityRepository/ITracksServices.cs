using Services.DTO;

namespace Services.IEntityRepository
{
    public interface ITracksServices
    {
        Task<IEnumerable<TracksDto>> GetTracksList();
    }
}