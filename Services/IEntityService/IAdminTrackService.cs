using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminTrackService
    {
        Task<bool> Create(TrackCreateDto track);
    }
}
