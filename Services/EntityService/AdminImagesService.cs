using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminImagesService : IAdminImagesService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminImagesService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ImageDto entity)
        {
            if (_repositoryContext.Images.AsNoTracking().Count(a => a.Link == entity.Link) > 0)
                return false;

            var newImage = new Image
            {
                Link = entity.Link
            };
            _repositoryContext.Add(newImage);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var img = await _repositoryContext.Images.FindAsync(id);
            if (img is null)
                return false;

            _repositoryContext.Remove(img);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ImageDto>> Get() =>
            await _repositoryContext.Images
                .AsNoTracking()
                .Select(a => new ImageDto
                {
                    Id = a.Id,
                    Link = a.Link
                })
                .ToArrayAsync();

        public async Task<IEnumerable<ImageWhisCountDto>> GetByCount()
        {
            var query = await _repositoryContext.Images
                        .AsNoTracking()
                        .Where(a => !a.Link.Contains("livery"))
                        .OrderByDescending(a => a.Size)
                        .Select(a => new ImageWhisCountDto
                        {
                            Id = a.Id,
                            Link = a.Link,
                            ManufacturersCount = _repositoryContext.Manufacturers.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            ChassisCount = _repositoryContext.Chassis.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            LiveryCount = _repositoryContext.Chassis.AsNoTracking().Where(b => b.IdLivery == a.Id).Count(),
                            ChassisImgsCount = _repositoryContext.ChassisImgs.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            CountriesCount = _repositoryContext.Countries.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            EnginesCount = _repositoryContext.Engines.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            GrandPrixesCount = _repositoryContext.GrandPrixes.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            GrandPrixImgsCount = _repositoryContext.GrandPrixImgs.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            ParticipantImgCount = _repositoryContext.ParticipantImg.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            RacerImgsCount = _repositoryContext.RacerImgs.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            RacersCount = _repositoryContext.Racers.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            SeasonImgCount = _repositoryContext.SeasonImg.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            SeasonsCount = _repositoryContext.Seasons.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            TeamNamesCount = _repositoryContext.TeamNames.AsNoTracking().Where(b => b.IdImageLogo == a.Id).Count(),
                            TracksCount = _repositoryContext.Tracks.AsNoTracking().Where(b => b.IdImage == a.Id).Count(),
                            TrackСonfigurationsCount = _repositoryContext.TrackСonfigurations.AsNoTracking().Where(b => b.IdImage == a.Id).Count(), 
                            TyresCount = _repositoryContext.Tyres.AsNoTracking().Where(b => b.IdImage == a.Id).Count()
                        })
                        .Take(1000)
                        .ToArrayAsync();
 

            return query;
        }


        public async Task<ImageDto?> GetById(Guid Id) =>
             await _repositoryContext.Images
                .AsNoTracking()
                .Where(a => a.Id == Id)
                .Select(a => new ImageDto
                {
                    Id = a.Id,
                    Link = a.Link
                })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ImageDto>> GetByIdSeason(Guid idSeason) =>
            await _repositoryContext.SeasonImg
                .AsNoTracking()
                .Where(a => a.IdSeason == idSeason)
                .Select(a => new ImageDto
                {
                    Id = a.Image.Id,
                    Link = a.Image.Link
                })
                .ToArrayAsync();

        public async Task<bool> Update(ImageDto entity)
        {
            var image = await _repositoryContext.Images
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (image is null)
                return false;

            image.Link = entity.Link;
            _repositoryContext.Update(image);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
