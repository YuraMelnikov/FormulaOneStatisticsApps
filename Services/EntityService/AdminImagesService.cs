using Entities.Contexts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<IEnumerable<ImageDto>> GetByIdConstructor(Guid idConstructor) =>
            await _repositoryContext.ParticipantImg
                .AsNoTracking()
                .Where(a => a.Participant.IdTeamName == idConstructor)
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

        public string SaveImageFile(IFormFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var image = new Image
                {
                    Link = @"/assets/img/" + file.FileName,
                    Size = file.Length.ToString()
                };
                _repositoryContext.Add(image);
                _repositoryContext.SaveChanges();

                return image.Link;
            }
            catch
            {
                return "";
            }
        }

        public async Task<bool> Create(ImageCreateDto entity)
        {
            var image = await _repositoryContext.Images
                                .AsNoTracking()
                                .FirstOrDefaultAsync(a => a.Link == entity.Path);
            if (image is null)
                return false;

            var grandPrix = await _repositoryContext.GrandPrixes.FindAsync(entity.GrandPrix);
            if (grandPrix != null)
            {
                var grandPrixImg = new GrandPrixImg { IdGrandPrix = grandPrix.Id, IdImage = image.Id };
                _repositoryContext.Add(grandPrixImg);

                var seasonImg = new SeasonImg { IdImage = image.Id, IdSeason = grandPrix.IdSeason };
                _repositoryContext.Add(seasonImg);
                await _repositoryContext.SaveChangesAsync();
            }

            foreach (var participantId in entity.Participant)
            {
                var participant = await _repositoryContext.Participants.FindAsync(participantId);
                if (participant != null)
                {
                    var participantImg = new ParticipantImg { IdImage = image.Id, IdParticipant = participant.Id };
                    _repositoryContext.Add(participantImg);

                    var chassisImg = new ChassisImg { IdChassi = participant.IdChassis, IdImage = image.Id };
                    _repositoryContext.Add(chassisImg);

                    var racerImg = new RacerImg { IdImage = image.Id, IdRacer = participant.IdRacer };
                    _repositoryContext.Add(racerImg);

                    await _repositoryContext.SaveChangesAsync();
                }
            }

            return true;
        }
    }
}
