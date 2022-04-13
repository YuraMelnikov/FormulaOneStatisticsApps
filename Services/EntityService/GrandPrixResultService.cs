using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class GrandPrixResultService : IGrandPrixResultService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public GrandPrixResultService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

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
                    IdChassis = a.Participant.Chassis.IdManufacturer, Chassis = a.Participant.Chassis.Name, 
                    Circles = a.Lap.ToString(), Time = a.Time, AvrSpeed = a.AverageSpeed, 
                    Points = a.Points.ToString(), 
                    Note = a.Note
                });

            return await partisipants
                .OrderBy(a => a.PositionNum)
                .ThenByDescending(a => a.Circles.Length)
                .ThenByDescending(a => a.Circles)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<GrandPrixParticipantDto>> GetParticipant(Guid idGrandPrix)
        {
            var participant = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdGrandPrix == idGrandPrix)
                .Select(a => new GrandPrixParticipantDto { 
                    No = a.Number, 
                    TeamName = a.Team.Name, 
                    IdRacer = a.IdRacer, 
                    Racer = a.Racer.RacerNameEng, 
                    IdChassis = a.IdChassis, 
                    Chassis = a.Chassis.Name, 
                    IdEngine = a.Engine.IdManufacturer, 
                    Engine = a.Engine.Name, 
                    IdTyre = a.Tyre.IdManufacturer, 
                    Tyre = a.Tyre.Name
                });

            return await participant
                .OrderBy(a => a.TeamName)
                .ThenBy(a => a.No.Length)
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
                    Position = a.Position.ToString(),
                    IdRacer = a.Participant.IdRacer,
                    Racer = a.Participant.Racer.RacerNameEng, 
                    IdChassis = a.Participant.Chassis.IdManufacturer, 
                    Chassis = a.Participant.Chassis.Name, 
                    IdEngine = a.Participant.Engine.IdManufacturer,
                    Engine = a.Participant.Engine.Name, Time = a.Time, Gap = ""
                });

            return await qualification
                .OrderBy(a => a.Position.Length)
                .ThenBy(a => a.Position)
                .ToArrayAsync();
        }

        public async Task<GrandPrixResultRacerDto> GetRacerResult(Guid idParticipant)
        {
            var participant = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.IdParticipant == idParticipant);
            var p = _mapper.Map<GrandPrixResultRacerDto>(participant);
            return _mapper.Map<GrandPrixResultRacerDto>(participant);
        }

        public async Task<WinnerDto> GetWinner(Guid idGrandPrix)
        {
            var winner = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Include(a => a.Participant.Racer)
                .Include(a => a.Participant.Chassis)
                .FirstOrDefaultAsync(a => a.Participant.GrandPrix.Id == idGrandPrix && a.Position == 1);

            return _mapper.Map<WinnerDto>(winner);
        }
    }
}