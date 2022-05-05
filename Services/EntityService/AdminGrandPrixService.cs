using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminGrandPrixService : IAdminCRU<GrandPrixDto>
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminGrandPrixService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(GrandPrixDto entity)
        {
            if (_repositoryContext.GrandPrixes.AsNoTracking().Count(a => a.Number == entity.Number) > 0)
                return false;

            var newImage = await _repositoryContext.Images
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(a => a.Link == DefaulValues.DefaultImage);
            if (newImage is null)
                return false;

            var newGrandPrix = new GrandPrix
            {
                IdGrandPrixNames = entity.IdGrandPrixNames, 
                Date = entity.Date, 
                FullName = entity.FullName, 
                IdSeason = entity.IdSeason, 
                IdTrackСonfiguration = entity.IdTrackСonfiguration, 
                Number = entity.Number, 
                IdImage = newImage.Id, 
                NumberInSeason = entity.NumberInSeason, 
                NumberOfLap = entity.NumberOfLap, 
                Text = entity.Text, 
                Weather = entity.Weather
            };
            _repositoryContext.Add(newGrandPrix);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var grandPrix = await _repositoryContext.GrandPrixes.FindAsync(id);

            if (grandPrix is null)
                return false;

            _repositoryContext.Remove(grandPrix);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GrandPrixDto>> Get() =>
            await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Select(a => new GrandPrixDto
                {
                    IdGrandPrixNames = a.IdGrandPrixNames, 
                    Weather = a.Weather, 
                    Text = a.Text, 
                    NumberOfLap = a.NumberOfLap, 
                    NumberInSeason = a.NumberInSeason, 
                    Number = a.Number, 
                    Date = a.Date, 
                    FullName = a.FullName, 
                    GrandPrixNames = a.GrandPrixName.FullName, 
                    Id = a.Id, 
                    IdSeason = a.IdSeason, 
                    IdTrackСonfiguration = a.IdTrackСonfiguration, 
                    Image = a.Image.Link, 
                    Season = a.Season.Year.ToString()
                })
                .OrderBy(a => a.Number)
                .ToArrayAsync();

        public async Task<GrandPrixDto?> GetById(Guid Id) =>
             await _repositoryContext.GrandPrixes
                .AsNoTracking()
                .Where(a => a.Id == Id)
                .Select(a => new GrandPrixDto
                {
                    IdGrandPrixNames = a.IdGrandPrixNames,
                    Weather = a.Weather,
                    Text = a.Text,
                    NumberOfLap = a.NumberOfLap,
                    NumberInSeason = a.NumberInSeason,
                    Number = a.Number,
                    Date = a.Date,
                    FullName = a.FullName,
                    GrandPrixNames = a.GrandPrixName.FullName,
                    Id = a.Id,
                    IdSeason = a.IdSeason,
                    IdTrackСonfiguration = a.IdTrackСonfiguration,
                    Image = a.Image.Link,
                    Season = a.Season.Year.ToString()
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Update(GrandPrixDto entity)
        {
            var grandPrix = await _repositoryContext.GrandPrixes
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (grandPrix is null)
                return false;

            var newImage = await _repositoryContext.Images
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Link == entity.Image);
            if (newImage is null)
                return false;

            grandPrix.IdImage = newImage.Id;
            _repositoryContext.Update(grandPrix);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
