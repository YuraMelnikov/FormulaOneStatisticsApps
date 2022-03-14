using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IChassiRepository Chassi { get; }
        ICountryRepository Country { get; }
        IEngineRepository Engine { get; }
        IFastLapRepository FastLap { get; }
        IGPRepository GP { get; }
        IGPResultRepository GPResult { get; }
        IImageRepository Image { get; }
        ILeaderLapRepository LeaderLap { get; }
        IManufacturerRepository Manufacturer { get; }
        IParticipantRepository Participant { get; }
        IQualificationRepository Qualification { get; }
        IRacerRepository Racer { get; }
        ISeasonRepository Season { get; }
        ITeamNameRepository TeamName { get; }
        ITeamRepository Team { get; }
        ITrackСonfigurationRepository TrackConfiguration { get; }
        ITrackRepository Track { get; }
        ITyreRepository Tyre { get; }
        Task SaveAsync();
    }
}
