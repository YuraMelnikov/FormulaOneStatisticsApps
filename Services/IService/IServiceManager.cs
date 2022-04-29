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

        Task SaveAsync();
    }
}
