using AutoMapper;
using Entities.Contexts;
using Services.DTOCRUD;
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
        private ITrackService _track;
        private ITracksService _tracks;
        private IRacersService _racers;
        private IManufacturersService _manufacturers;
        private IManufacturerService _manufacturer;
        private ISeasonService _season;
        private IGrandPrixService _grandPrixResult;
        private IRacerService _racerService;
        private IConstructorsService _constructorsService;
        private IConstructorService _constructorService;
        private IChassisService _chassisService;
        private IAdminCRU<SeasonDto> _adminSeason;
        private IAdminImagesService _adminImages;
        private IAdminCRU<ConstructorDto> _adminConstructor;
        private IAdminCRU<CountryDto> _adminCountry;
        private IAdminGrandPrixService _adminGrandPrix;
        private IAdminQualificationService _adminQualification;
        private IAdminGrandPrixResultService _adminGrandPrixResult;
        private IAdminManufacturerService _adminManufacturer;
        private IAdminChassisService _adminChassis;
        private IAdminEngineService _adminEngineService;
        private IAdminTeamNameService _adminTeamName;
        private IAdminTeamService _adminTeam;
        private IAdminTrackService _adminTrack;
        private IAdminTrackConfigurationService _adminTrackConfiguration;
        private IAdminGrandPrixNamesService _adminGrandPrixNamesService;
        private IAdminImportService _adminImportService;

        public ServiceManager(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        public IAdminImportService AdminImport
        {
            get
            {
                if (_adminImportService == null)
                    _adminImportService = new AdminImportService(_repoContext);
                return _adminImportService;
            }
        }

        public IAdminGrandPrixNamesService AdminGrandPrixNames
        {
            get
            {
                if (_adminGrandPrixNamesService == null)
                    _adminGrandPrixNamesService = new AdminGrandPrixNamesService(_repoContext);
                return _adminGrandPrixNamesService;
            }
        }

        public IAdminTrackConfigurationService AdminTrackConfiguration
        {
            get
            {
                if (_adminTrackConfiguration == null)
                    _adminTrackConfiguration = new AdminTrackConfigurationService(_repoContext);
                return _adminTrackConfiguration;
            }
        }

        public IAdminTrackService AdminTrack
        {
            get
            {
                if (_adminTrack == null)
                    _adminTrack = new AdminTrackService(_repoContext);
                return _adminTrack;
            }
        }

        public IAdminTeamNameService AdminTeamName
        {
            get
            {
                if (_adminTeamName == null)
                    _adminTeamName = new AdminTeamNameService(_repoContext);
                return _adminTeamName;
            }
        }

        public IAdminTeamService AdminTeam
        {
            get
            {
                if (_adminTeam == null)
                    _adminTeam = new AdminTeamService(_repoContext);
                return _adminTeam;
            }
        }

        public IAdminEngineService AdminEngine
        {
            get
            {
                if (_adminEngineService == null)
                    _adminEngineService = new AdminEngineService(_repoContext);
                return _adminEngineService;
            }
        }

        public IAdminChassisService AdminChassis
        {
            get
            {
                if (_adminChassis == null)
                    _adminChassis = new AdminChassisService(_repoContext);
                return _adminChassis;
            }
        }

        public IAdminManufacturerService AdminManufacturer
        {
            get
            {
                if (_adminManufacturer == null)
                    _adminManufacturer = new AdminManufacturerService(_repoContext);
                return _adminManufacturer;
            }
        }

        public IAdminGrandPrixResultService AdminGrandPrixResult
        {
            get
            {
                if (_adminGrandPrixResult == null)
                    _adminGrandPrixResult = new AdminGrandPrixResultService(_repoContext);
                return _adminGrandPrixResult;
            }
        }

        public IAdminQualificationService AdminQualification
        {
            get
            {
                if (_adminQualification == null)
                    _adminQualification = new AdminQualificationService(_repoContext);
                return _adminQualification;
            }
        }

        public IAdminGrandPrixService AdminGrandPrix
        {
            get
            {
                if (_adminGrandPrix == null)
                    _adminGrandPrix = new AdminGrandPrixService(_repoContext);
                return _adminGrandPrix;
            }
        }

        public IAdminCRU<CountryDto> AdminCountry
        {
            get
            {
                if (_adminCountry == null)
                    _adminCountry = new AdminCountryService(_repoContext);
                return _adminCountry;
            }
        }

        public IAdminCRU<ConstructorDto> AdminConstructor
        {
            get
            {
                if (_adminConstructor == null)
                    _adminConstructor = new AdminConstructorService(_repoContext);
                return _adminConstructor;
            }
        }

        public IAdminImagesService AdminImages
        {
            get
            {
                if (_adminImages == null)
                    _adminImages = new AdminImagesService(_repoContext);
                return _adminImages;
            }
        }

        public IAdminCRU<SeasonDto> AdminSeason
        {
            get
            {
                if (_adminSeason == null)
                    _adminSeason = new AdminSeasonService(_repoContext);
                return _adminSeason;
            }
        }

        public IManufacturerService Manufacturer
        {
            get
            {
                if (_manufacturer == null)
                    _manufacturer = new ManufacturerService(_repoContext);
                return _manufacturer;
            }
        }

        public ITrackService Track
        {
            get
            {
                if (_track == null)
                    _track = new TrackService(_repoContext);
                return _track;
            }
        }

        public IChassisService Chassis
        {
            get
            {
                if (_chassisService == null)
                    _chassisService = new ChassisService(_repoContext);
                return _chassisService;
            }
        }

        public IConstructorService Constructor
        {
            get
            {
                if (_constructorService == null)
                    _constructorService = new ConstructorService(_repoContext);
                return _constructorService;
            }
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

        public ITracksService Tracks
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

        //public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}