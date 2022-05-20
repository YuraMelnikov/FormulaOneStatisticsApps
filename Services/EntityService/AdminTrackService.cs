using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminTrackService : IAdminTrackService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminTrackService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(TrackCreateDto track)
        {
            if (_repositoryContext.Tracks.Count(a => a.Name == track.Name) > 0)
                return false;

            var newTrack = new Track
            {
                Name = track.Name, 
                IdCountry = track.IdCountry, 
                Location = track.Location, 
                NameRus = track.NameRus,
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id
            };
            _repositoryContext.Add(newTrack);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}