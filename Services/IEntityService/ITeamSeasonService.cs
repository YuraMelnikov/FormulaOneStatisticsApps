using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface ITeamSeasonService
    {
        Task<IEnumerable<LabelItemWhisId>> GetRacersTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetTyreTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetChassisTeamOnSeason(Guid idSeason, Guid idTeam);
        Task<IEnumerable<LabelItemWhisId>> GetEngineTeamOnSeason(Guid idSeason, Guid idTeam);
    }
}