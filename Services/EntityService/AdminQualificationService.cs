using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminQualificationService : IAdminQualificationService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminQualificationService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Delete(QualificationDto qualification)
        {
            var entity = await _repositoryContext.Qualifications.FindAsync(qualification.Id);
            if (entity is null)
                return false;

            _repositoryContext.Remove(entity);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }

        public async Task<QualificationDto> Get(Guid id) =>
            await _repositoryContext.Qualifications
                    .AsNoTracking()
                    .Where(a => a.Id == id)
                    .Select(a => new QualificationDto
                    {
                        Id = a.Id,
                        Time = a.Time
                    })
                    .FirstOrDefaultAsync();

        public async Task<bool> Update(QualificationDto qualification)
        {
            var entity = await _repositoryContext.Qualifications.FindAsync(qualification.Id);
            if (entity is null)
                return false;

            entity.Time = qualification.Time;
            _repositoryContext.Update(entity);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
