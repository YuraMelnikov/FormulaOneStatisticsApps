using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminTrackConfigurationService : IAdminTrackConfigurationService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminTrackConfigurationService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(TrackConfigurationCreateDto conf)
        {
            if (_repositoryContext.TrackСonfigurations.Count(a => a.Note == conf.Note && a.IdTrack == conf.IdTrack) > 0)
                return false;

            var newConf = new TrackСonfiguration
            {
                IdTrack = conf.IdTrack, 
                Length = conf.Length, 
                Note = conf.Note, 
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id
            };
            _repositoryContext.Add(newConf);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}