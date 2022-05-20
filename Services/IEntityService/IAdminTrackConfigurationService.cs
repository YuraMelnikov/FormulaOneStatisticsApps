using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminTrackConfigurationService
    {
        Task<bool> Create(TrackConfigurationCreateDto conf);
    }
}
