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

        public async Task<WinnerDto> GetWinner(Guid idGrandPrix)
        {
            var winner = await _repositoryContext.GrandPrixResults
                .AsNoTracking()
                .Include(a => a.Participant.Racer)
                .Include(a => a.Participant.Team)
                .FirstOrDefaultAsync(a => a.Participant.GrandPrix.Id == idGrandPrix && a.Position == 1);

            return _mapper.Map<WinnerDto>(winner);
        }
    }
}