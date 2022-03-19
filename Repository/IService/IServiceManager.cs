using Repository.IEntityRepository;

namespace Repository.IService
{
    public interface IServiceManager
    {
        //IChassiRepository Chassi { get; }
        //ICountryRepository Country { get; }
        //IEngineRepository Engine { get; }
        //IFastLapRepository FastLap { get; }
        //IGrandPrixRepository GP { get; }
        //IGrandPrixResultRepository GPResult { get; }
        //IImageRepository Image { get; }
        //ILeaderLapRepository LeaderLap { get; }
        //IManufacturerRepository Manufacturer { get; }
        //IParticipantRepository Participant { get; }
        //IQualificationRepository Qualification { get; }
        //IRacerRepository Racer { get; }
        ISeasonsService Seasons { get; }
        IManufacturersService Manufacturers { get; }
        ITracksServices Tracks { get; }
        IRacersService Racers { get; }
        //ITeamNameRepository TeamName { get; }
        //ITeamRepository Team { get; }
        //ITrackСonfigurationRepository TrackConfiguration { get; }
        //ITrackRepository Track { get; }
        //ITyreRepository Tyre { get; }
        Task SaveAsync();
    }
}
