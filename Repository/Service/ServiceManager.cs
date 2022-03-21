using AutoMapper;
using Entities.Contexts;
using Services.EntityRepository;
using Services.IEntityRepository;
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

        public ServiceManager(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        public ISeasonsService Seasons
        {
            get
            {
                if (_seasons == null)
                    _seasons = new SeasonsService(_repoContext, _mapper);
                return _seasons;
            }
        }

        public IManufacturersService Manufacturers
        {
            get
            {
                if (_manufacturers == null)
                    _manufacturers = new ManufacturersService(_repoContext, _mapper);
                return _manufacturers;
            }
        }

        public ITracksServices Tracks
        {
            get
            {
                if (_tracks == null)
                    _tracks = new TracksServices(_repoContext, _mapper);
                return _tracks;
            }
        }

        public IRacersService Racers
        {
            get
            {
                if (_racers == null)
                    _racers = new RacersService(_repoContext, _mapper);
                return _racers;
            }
        }

        public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}