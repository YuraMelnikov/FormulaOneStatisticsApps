using AutoMapper;
using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.IEntityRepository;
using Repository.Service;

namespace Repository.EntityRepository
{
    public class TracksServices : RepositoryBase<Track, TracksDto>, ITracksServices
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public TracksServices(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext, mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TracksDto>> GetTracksList()
        {
            var tracksList = await _repositoryContext.Tracks
                .AsNoTracking()
                .Include(a => a.Image)
                .OrderBy(a => a.Name)
                .ToArrayAsync();
            return _mapper.Map<IEnumerable<TracksDto>>(tracksList);
        }
    }
}