using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class QualificationRepository : RepositoryBase<Qualification>, IQualificationRepository
    {
        public QualificationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateQualification(Qualification qualification) =>
            Create(qualification);

        public void DeleteQualification(Qualification qualification) =>
            Delete(qualification);

        public async Task<IEnumerable<Qualification>> GetAllQualificationAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Qualification> GetQualificationAsync(Guid qualificationId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(qualificationId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
