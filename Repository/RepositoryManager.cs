using Entities;
using Contracts;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repoContext;
        private IChassiRepository _chassi;
        private ICountryRepository _country;
        private IEngineRepository _engine;
        private IFastLapRepository _fastLap;
        private IGPRepository _gP;
        private IGPResultRepository _gPResult;
        private IImageRepository _image;
        private ILeaderLapRepository _leaderLap;
        private IManufacturerRepository _manufacturer;
        private IParticipantRepository _participant;
        private IQualificationRepository _qualification;
        private IRacerRepository _racer;
        private ISeasonRepository _season;
        private ITeamNameRepository _teamName;
        private ITeamRepository _team;
        private ITrackСonfigurationRepository _trackConfiguration;
        private ITrackRepository _track;
        private ITyreRepository _tyre;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IChassiRepository Chassi
        {
            get
            {
                if (_chassi == null)
                    _chassi = new ChassiRepository(_repoContext);
                return _chassi;
            }
        }

        public ICountryRepository Country 
        {
            get
            {
                if(_country == null)
                    _country = new CountryRepository(_repoContext);
                return _country;
            }
        }

        public IEngineRepository Engine 
        {
            get 
            {
                if(_engine == null)
                    _engine = new EngineRepository(_repoContext);
                return _engine;
            }
        }

        public IFastLapRepository FastLap 
        {
            get 
            { 
                if(_fastLap == null)
                    _fastLap = new FastLapRepository(_repoContext);
                return _fastLap;
            }
        }

        public IGPRepository GP 
        {
            get
            {
                if(_gP == null)
                    _gP = new GPRepository(_repoContext);
                return _gP;
            }
        }

        public IGPResultRepository GPResult 
        {
            get
            {
                if(_gPResult == null)
                    _gPResult = new GPResultRepository(_repoContext);
                return _gPResult;
            }
        }

        public IImageRepository Image 
        {
            get 
            { 
                if(_image == null)
                    _image = new ImageRepository(_repoContext);
                return _image;
            }
        }

        public ILeaderLapRepository LeaderLap 
        {
            get 
            {
                if(_leaderLap == null)
                    _leaderLap = new LeaderLapRepository(_repoContext);
                return _leaderLap;
            }
        }

        public IManufacturerRepository Manufacturer 
        {
            get 
            { 
                if(_manufacturer == null)
                    _manufacturer = new ManufacturerRepository(_repoContext);
                return _manufacturer;
            }
        }

        public IParticipantRepository Participant
        {
            get
            {
                if(_participant == null)
                    _participant = new ParticipantRepository(_repoContext);
                return _participant;
            }
        }

        public IQualificationRepository Qualification
        {
            get
            {
                if(_qualification == null)
                    _qualification = new QualificationRepository(_repoContext);
                return _qualification;
            }
        }

        public IRacerRepository Racer
        {
            get
            {
                if(_racer == null)
                    _racer = new RacerRepository(_repoContext);
                return _racer;
            }
        }

        public ISeasonRepository Season
        {
            get
            {
                if(_season == null)
                    _season = new SeasonRepository(_repoContext);
                return _season;
            }
        }

        public ITeamNameRepository TeamName
        {
            get
            {
                if (_teamName == null)
                    _teamName = new TeamNameRepository(_repoContext);
                return _teamName;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if(_team == null)
                    _team = new TeamRepository(_repoContext);
                return _team;
            }
        }

        public ITrackСonfigurationRepository TrackConfiguration
        {
            get
            {
                if(_trackConfiguration == null)
                    _trackConfiguration = new TrackConfigurationRepository(_repoContext);
                return _trackConfiguration;
            }
        }

        public ITrackRepository Track
        {
            get
            {
                if(_track == null)
                    _track = new TrackRepository(_repoContext);
                return _track;
            }
        }

        public ITyreRepository Tyre
        {
            get
            {
                if(_tyre == null)
                    _tyre = new TyreRepository(_repoContext);
                return _tyre;
            }
        }

        public Task SaveAsync() => _repoContext.SaveChangesAsync();
    }
}
