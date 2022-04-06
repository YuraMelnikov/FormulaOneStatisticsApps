using Entities.Contexts;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class RacerService : IRacerService
    {
        private readonly RepositoryContext _repositoryContext;

        public RacerService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task<IEnumerable<RacerResultsByYears>> GetResultBySeason(Guid racerId)
        {
            throw new NotImplementedException();
        }
    }
}
