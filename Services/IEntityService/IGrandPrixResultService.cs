using Services.DTO;

namespace Services.IEntityService
{
    public interface IGrandPrixResultService
    {
        Task<WinnerDto> GetWinner(Guid idGrandPrix);
        Task<GrandPrixResultRacerDto> GetRacerResult(Guid idParticipant);
        Task<IEnumerable<GrandPrixParticipantDto>> GetParticipant(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixQualificationDto>> GetQualification(Guid idGrandPrix);
        Task<IEnumerable<GrandPrixClassificationDto>> GetClassification(Guid idGrandPrix);
    }
}
