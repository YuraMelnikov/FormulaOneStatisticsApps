using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllImageAsync(bool trackChanges);
        Task<Image> GetImageAsync(Guid imageId, bool trackChanges);
        void CreateImage(Image image);
        void DeleteImage(Image image);
        Task<IEnumerable<Image>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
