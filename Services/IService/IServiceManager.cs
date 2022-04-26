using Services.IEntityService;

namespace Services.IService
{
    public interface IServiceManager
    {
        ISeasonService Season { get; }
        ISeasonsService Seasons { get; }
        IManufacturersService Manufacturers { get; }
        ITracksServices Tracks { get; }
        IRacersService Racers { get; }
        IGrandPrixService GrandPrixResult { get; }
        IRacerService Racer { get; }
        IConstructorsService Constructors { get; }
        IConstructorService Constructor { get; }
        IChassisService Chassis { get; }
        Task SaveAsync();
    }
}
