using Services.DTO;

namespace Services.IEntityService
{
    public interface ITracksService
    {
        Task<IEnumerable<TracksDto>> GetTracksList();
    }
}