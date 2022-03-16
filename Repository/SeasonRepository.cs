using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
    {
        public SeasonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateSeason(Season season) =>
            Create(season);

        public void DeleteSeason(Season season) =>
            Delete(season);

        public async Task<IEnumerable<Season>> GetAllSeasonAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .AsNoTracking()
            .Include(c => c.Image)
            .OrderBy(c => c.Year)
            .ToListAsync();

        public async Task<Season> GetSeasonAsync(Guid seasonId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(seasonId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
