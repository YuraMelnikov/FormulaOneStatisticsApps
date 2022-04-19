using Services.DTO;
using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IGrandPrixService
    {
        Task<IEnumerable<GrandPrixParticipantDto>> GetParticipant(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixQualificationDto>> GetQualification(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixClassificationDto>> GetClassification(Guid idGrandPrix);
        Task<GrandPrixInfoDto> GetInfo(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixChampStateDto>> GetChampRacers(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixChampStateDto>> GetChampConstructors(Guid idGrandPrix);
        Task<IEnumerable<ImageDto>> GetImages(Guid idGrandPrix);
    }
}
