using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminGrandPrixResult : IAdminGrandPrixResult
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminGrandPrixResult(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<GrandPrixResultDto> Get(Guid id) =>
            await _repositoryContext.GrandPrixResults
                    .AsNoTracking()
                    .Where(a => a.Id == id)
                    .Select(a => new GrandPrixResultDto
                    {
                        Id = a.Id,
                        Classification = a.Classification,
                        ClassificationRus = a.ClassificationRus,
                        Note = a.Note,
                        NoteRus = a.NoteRus
                    })
                    .FirstOrDefaultAsync();

        public async Task<bool> Update(GrandPrixResultDto result)
        {
            var entity = await _repositoryContext.GrandPrixResults.FindAsync(result.Id);
            if (entity is null)
                return false;

            entity.Note = result.Note;
            entity.NoteRus = result.NoteRus;
            entity.ClassificationRus = result.ClassificationRus;
            entity.Classification = result.Classification;
            _repositoryContext.Update(entity);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
