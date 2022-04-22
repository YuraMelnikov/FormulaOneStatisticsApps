using AutoMapper;
using Entities.Contexts;
using Services.EntityService;
using Services.IEntityService;
using Services.IService;

namespace Services.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly RepositoryContext _repoContext;
        private readonly IMapper _mapper;

        private ISeasonsService _seasons;
        private ITracksServices _tracks;
        private IRacersService _racers;
        private IManufacturersService _manufacturers;
        private ISeasonService _season;
        private IGrandPrixService _grandPrixResult;
        private IRacerService _racerService;
        private IConstructorsService _constructorsService;

        public ServiceManager(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        public IConstructorsService Constructors
        {
            get
            {
                if (_constructorsService == null)
                    _constructorsService = new ConstructorsService(_repoContext);
                return _constructorsService;
            }
        }

        public IRacerService Racer
        {
            get
            {
                if (_racerService == null)
                    _racerService = new RacerService(_repoContext);
                return _racerService;
            }
        }

        public ISeasonService Season
        {
            get
            {
                if(_season == null)
                    _season = new SeasonService(_repoContext);
                return _season;
            }
        }

        public ISeasonsService Seasons
        {
            get
            {
                if (_seasons == null)
                    _seasons = new SeasonsService(_repoContext);
                return _seasons;
            }
        }

        public IManufacturersService Manufacturers
        {
            get
            {
                if (_manufacturers == null)
                    _manufacturers = new ManufacturersService(_repoContext);
                return _manufacturers;
            }
        }

        public ITracksServices Tracks
        {
            get
            {
                if (_tracks == null)
                    _tracks = new TracksServices(_repoContext);
                return _tracks;
            }
        }

        public IRacersService Racers
        {
            get
            {
                if (_racers == null)
                    _racers = new RacersService(_repoContext);
                return _racers;
            }
        }

        public IGrandPrixService GrandPrixResult
        {
            get
            {
                if (_grandPrixResult == null)
                    _grandPrixResult = new GrandPrixService(_repoContext);
                return _grandPrixResult;
            }
        }

        public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}