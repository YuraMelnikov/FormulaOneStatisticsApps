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
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateImage(Image image) =>
            Create(image);

        public void DeleteImage(Image image) =>
            Delete(image);

        public async Task<IEnumerable<Image>> GetAllImageAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Image> GetImageAsync(Guid imageId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(imageId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Image>> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(a => ids.Contains(a.Id), trackChanges)
            .ToListAsync();
    }
}