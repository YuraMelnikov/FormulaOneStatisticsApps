using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class TracksServices :  ITracksService
    {
        private readonly RepositoryContext _repositoryContext;

        public TracksServices(RepositoryContext repositoryContext) => 
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<TracksDto>> GetTracksList() =>
            await _repositoryContext.Tracks
                .AsNoTracking()
                .Select(a => new TracksDto { Id = a.Id, Name = a.Name, ImageLink = a.Image.Link })
                .OrderBy(a => a.Name)
                .ToArrayAsync();
    }
}