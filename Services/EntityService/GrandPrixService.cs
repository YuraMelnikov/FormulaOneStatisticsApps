using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class GrandPrixService : IGrandPrixService
    {
        private readonly RepositoryContext _repositoryContext;

        public GrandPrixService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<GrandPrixChampStateDto>> GetChampConstructors(Guid idGrandPrix) =>
            await _repositoryContext.ChampConstructorPastRace
                .AsNoTracking()
                .Where(a => a.IdGrandPrix == idGrandPrix)
                .OrderBy(a => a.Position)
                .Select(a => new GrandPrixChampStateDto
                {
                    Name = a.TeamName.Name,
                    Points = a.Points,
                    Position = a.Position
                })
                .ToArrayAsync();

        public async Task<IEnumerable<GrandPrixChampStateDto>> GetChampRacers(Guid idGrandPrix) =>
            await _repositoryContext.ChampRacersPastRace
                .AsNoTracking()
                .Where(a => a.IdGrandPrix == idGrandPrix)
                .OrderBy(a => a.Position)
                .Select(a => new GrandPrixChampStateDto
                {
                    Name = a.Racer.RacerNameEng,
                    Points = a.Points,
                    Position = a.Position
                })
                .ToArrayAsync();

        public async Task<IEnumerable<GrandPrixClassificationDto>> GetClassification(Guid idGrandPrix)
        {
            var partisipants = _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Where(a => a.Participant.IdGrandPrix == idGrandPrix)
                .Select(a => new GrandPrixClassificationDto
                {
                    PositionNum = a.Position,
                    Position = a.Classification,
                    IdRacer = a.Participant.IdRacer,
                    Racer = a.Participant.Racer.RacerNameEng,
                    IdChassis = a.Participant.Chassis.IdManufacturer,
                    Chassis = a.Participant.Chassis.Name,
                    Circles = a.Lap.ToString(),
                    Time = a.TimeLag,
                    AvrSpeed = a.AverageSpeed,
                    Points = a.Points.ToString(),
                    Note = a.Note
                });

            return await partisipants
                .OrderBy(a => a.PositionNum)
                .ThenByDescending(a => a.Circles.Length)
                .ThenByDescending(a => a.Circles)
                .ToArrayAsync();
        }

        public async Task<GrandPrixFastLapDto> GetFastLap(Guid idGrandPrix) =>
            await _repositoryContext.FastLaps
                    .AsNoTracking()
                    .Where(a => a.Participant.IdGrandPrix == idGrandPrix)
                    .Select(a => new GrandPrixFastLapDto
                    {
                        Racer = a.Participant.Racer.RacerNameEng, 
                        Time = a.Time, 
                        AverageSpeed = a.AverageSpeed
                    })
                    .FirstAsync();

    public async Task<IEnumerable<ImageDto>> GetImages(Guid idGrandPrix) =>
            await _repositoryContext.GrandPrixImgs
                .AsNoTracking()
                .Where(a => a.IdGrandPrix == idGrandPrix)
                .Select(a => new ImageDto
                {
                    Link = a.Image.Link, 
                    Text = string.Concat(_repositoryContext.ParticipantImg
                        .Where(b => b.IdImage == a.IdImage)
                        .Select(b => b.Participant.Racer.RacerNameEng + ", " + b.Participant.Chassis.Name + " ")
                        .ToList())
                    .TrimEnd(' ')
                })
                .ToArrayAsync();

        public async Task<GrandPrixInfoDto> GetInfo(Guid idGrandPrix) =>
            await _repositoryContext.GrandPrixes
                    .AsNoTracking()
                    .Where(a => a.Id == idGrandPrix)
                    .Select(a => new GrandPrixInfoDto
                    {
                        Name = a.FullName, 
                        ImgLink = a.Image.Link, 
                        Date = a.Date.ToShortDateString(), 
                        ImgTrackLink = a.TrackСonfiguration.Image.Link, 
                        NumberInSeason = a.NumberInSeason, 
                        Text = a.Text, 
                        TrackName = a.TrackСonfiguration.Track.Name, 
                        Weather = a.Weather
                    })
                    .FirstAsync();

        public Task<IEnumerable<GrandPrixLastResultDto>> GetLastResult() => 
            await _repositoryContext.GrandPrixResults
                .Where(a => a.Participant.IdGrandPrix == _repositoryContext.GrandPrixes.First(a => a.Number == _repositoryContext.GrandPrixes.Max(a => a.Number)).Id)
                .Where(a => a.Position < 11)
                .Select(a => new GrandPrixLastResultDto
                { 
                    Position = a.Position, Constructor = a.Participant.TeamName.Name, Points = a.Points
                })
                .ToArrayAsync();

        public async Task<IEnumerable<GrandPrixLeaderLapDto>> GetLeaderLap(Guid idGrandPrix) =>
            await _repositoryContext.LeaderLaps
                .AsNoTracking()
                .Where(a => a.Participant.IdGrandPrix == idGrandPrix)
                .Select(a => new GrandPrixLeaderLapDto
                {
                    Racer = a.Participant.Racer.RacerNameEng,
                    First = a.First,
                    Last = a.Last
                })
                .ToArrayAsync();

        public async Task<IEnumerable<GrandPrixParticipantDto>> GetParticipant(Guid idGrandPrix)
        {
            var participant = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdGrandPrix == idGrandPrix)
                .Select(a => new GrandPrixParticipantDto
                {
                    Id = a.Id,
                    No = a.Number,
                    TeamName = a.Team.Name,
                    IdRacer = a.IdRacer,
                    Racer = a.Racer.RacerNameEng,
                    IdChassis = a.IdChassis,
                    Chassis = a.Chassis.Name,
                    IdEngine = a.Engine.IdManufacturer,
                    Engine = a.Engine.Name,
                    IdTyre = a.Tyre.IdManufacturer,
                    Tyre = a.Tyre.Name, 
                    Constructor = a.TeamName.Name, 
                    Livery = a.Chassis.Livery.Link
                });

            return await participant
                .OrderBy(a => a.No.Length)
                .ThenBy(a => a.No)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<GrandPrixQualificationDto>> GetQualification(Guid idGrandPrix)
        {
            var qualification = _repositoryContext.Qualifications
                .AsNoTracking()
                .Where(a => a.Participant.IdGrandPrix == idGrandPrix)
                .Select(a => new GrandPrixQualificationDto
                {
                    Id = a.Id,
                    Position = a.Position.ToString(),
                    IdRacer = a.Participant.IdRacer,
                    Racer = a.Participant.Racer.RacerNameEng,
                    IdChassis = a.Participant.Chassis.IdManufacturer,
                    Chassis = a.Participant.Chassis.Name,
                    IdEngine = a.Participant.Engine.IdManufacturer,
                    Engine = a.Participant.Engine.Name,
                    Time = a.Time,
                    Gap = ""
                });

            return await qualification
                .OrderBy(a => a.Position.Length)
                .ThenBy(a => a.Position)
                .ToArrayAsync();
        }
    }
}