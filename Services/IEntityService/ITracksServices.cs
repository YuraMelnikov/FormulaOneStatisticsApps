using Services.DTO;

namespace Services.IEntityService
{
    public interface ITracksServices
    {
        Task<IEnumerable<TracksDto>> GetTracksList();
    }
}