using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.IService
{
    public interface IServiceManager
    {
        ISeasonService Season { get; }
        ISeasonsService Seasons { get; }
        IManufacturersService Manufacturers { get; }
        ITrackService Track { get; }
        ITracksService Tracks { get; }
        IRacersService Racers { get; }
        IGrandPrixService GrandPrixResult { get; }
        IRacerService Racer { get; }
        IConstructorsService Constructors { get; }
        IConstructorService Constructor { get; }
        IChassisService Chassis { get; }
        IManufacturerService Manufacturer { get; }
        IAdminCRU<SeasonDto> AdminSeason { get; }
        IAdminImagesService AdminImages { get; }
        IAdminCRU<ConstructorDto> AdminConstructor{ get; }
        IAdminCRU<CountryDto> AdminCountry { get; }
        IAdminGrandPrixService AdminGrandPrix { get; }
        IAdminQualificationService AdminQualification { get; }
        IAdminGrandPrixResultService AdminGrandPrixResult { get; }
        IAdminManufacturerService AdminManufacturer { get; }
        IAdminChassisService AdminChassis { get; }
        IAdminEngineService AdminEngine { get; }
        IAdminTeamNameService AdminTeamName { get; }
        IAdminTeamService AdminTeam { get; }
        IAdminTrackService AdminTrack { get; }
        IAdminTrackConfigurationService AdminTrackConfiguration { get; }
        IAdminGrandPrixNamesService AdminGrandPrixNames { get; }
    }
}
