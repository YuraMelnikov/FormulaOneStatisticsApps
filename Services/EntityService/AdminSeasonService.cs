using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminSeasonService : IAdminCRU<SeasonDto>
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminSeasonService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(SeasonDto entity)
        {
            if (entity.Year < DefaulValues.MinimumSeasonYear)
                return false;

            if (_repositoryContext.Seasons.AsNoTracking().Count(a => a.Year == entity.Year) > 0)
                return false;

            var newImage = await _repositoryContext.Images
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(a => a.Link == DefaulValues.DefaultImage);
            if (newImage is null)
                return false;

            var newSeason = new Season
            {
                IdImage = newImage.Id,
                Year = entity.Year
            };
            _repositoryContext.Add(newSeason);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SeasonDto>> Get() =>
            await _repositoryContext.Seasons
                .AsNoTracking()
                .Select(a => new SeasonDto 
                { 
                    Id = a.Id,
                    Year = a.Year, 
                    Link = a.Image.Link 
                })
                .ToArrayAsync();

        public async Task<SeasonDto?> GetById(Guid Id) =>
             await _repositoryContext.Seasons
                .AsNoTracking()
                .Where(a => a.Id == Id)
                .Select(a => new SeasonDto
                {
                    Id = a.Id,
                    Year = a.Year,
                    Link = a.Image.Link
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Update(SeasonDto entity)
        {
            var season = await _repositoryContext.Seasons
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (season is null)
                return false;

            var newImage = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == entity.Link);
            if (newImage is null)
                return false;

            season.IdImage = newImage.Id;
            _repositoryContext.Update(season);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
