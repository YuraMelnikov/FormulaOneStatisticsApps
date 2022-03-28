using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class SeasonService : ISeasonService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IMapper _mapper;

        public SeasonService(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CalendarSeasonDto>> GetClendarSeason(Guid seasonId)
        {
            var query = await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.IdSeason == seasonId)
                .Include(a => a.Image)
                .Include(a => a.TrackСonfiguration.Track)
                .OrderBy(a => a.NumberInSeason)
                .ToArrayAsync();
            var calendar = _mapper.Map<IEnumerable<CalendarSeasonDto>>(query);

            foreach(var data in calendar)
            {
                var service = new GrandPrixResultService(_repositoryContext, _mapper);
                var winner = await service.GetWinner(data.IdGrandPrix);
                _mapper.Map(winner, data);
            }

            return calendar;
        }
    }
}
