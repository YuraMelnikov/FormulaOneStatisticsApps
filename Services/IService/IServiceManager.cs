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

        Task SaveAsync();
    }
}
