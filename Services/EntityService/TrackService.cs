using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    internal class TrackService : ITrackService
    {
        private readonly RepositoryContext _repositoryContext;

        public TrackService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<TrackConfigurationDto>> GetConfigurations(Guid trackId) =>
            await _repositoryContext.TrackСonfigurations
                .AsNoTracking()
                .Where(a => a.IdTrack == trackId)
                .Select(a => new TrackConfigurationDto
                {
                    Image = a.Image.Link,
                    Length = a.Length,
                    Seasons = _repositoryContext.GrandPrixes
                                    .AsNoTracking()
                                    .Where(b => b.IdTrackСonfiguration == a.Id)
                                    .Select(b => new LabelItemWhisId
                                    {
                                        Id = b.IdSeason,
                                        Name = b.Season.Year.ToString()
                                    })
                                    .ToArray()
                })
                .ToArrayAsync();

        public async Task<IEnumerable<TrackGrandPrixDto>> GetGrandPrix(Guid trackId) =>
            await _repositoryContext.GrandPrixResults
                                .AsNoTracking()
                                .Where(a => a.Participant.GrandPrix.TrackСonfiguration.IdTrack == trackId && a.Position == 1)
                                .Select(a => new TrackGrandPrixDto
                                {
                                    id = a.Participant.IdGrandPrix,
                                    Date = a.Participant.GrandPrix.Date.ToShortDateString(), 
                                    Name = a.Participant.GrandPrix.GrandPrixName.ShortName, 
                                    IdWinnerRacer = a.Participant.IdRacer, 
                                    IdWinnerTeam = a.Participant.IdChassis, 
                                    Number = a.Participant.GrandPrix.Number, 
                                    RacerWinner = a.Participant.Racer.RacerNameEng, 
                                    TeamWinner = a.Participant.Chassis.Name, 
                                    Weather = a.Participant.GrandPrix.Weather
                                })
                                .ToArrayAsync();

        public async Task<IEnumerable<ImageDto>> GetImages(Guid trackId) =>
            await _repositoryContext.GrandPrixImgs
                            .AsNoTracking()
                            .Where(a => a.GrandPrix.TrackСonfiguration.IdTrack == trackId)
                            .Select(a => new ImageDto
                            {
                                Link = a.Image.Link,
                                Text = ""
                            })
                            .ToArrayAsync();

    }
}
