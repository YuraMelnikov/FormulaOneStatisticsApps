using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackGrandPrixDto>> GetGrandPrix(Guid trackId);
        Task<IEnumerable<TrackConfigurationDto>> GetConfigurations(Guid trackId);
        Task<IEnumerable<ImageDto>> GetImages(Guid trackId);
    }
}
