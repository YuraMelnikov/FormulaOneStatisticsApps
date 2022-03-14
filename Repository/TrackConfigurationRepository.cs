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
    public class TrackConfigurationRepository : RepositoryBase<TrackСonfiguration>, ITrackСonfigurationRepository
    {
        public TrackConfigurationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTrackСonfiguration(TrackСonfiguration trackСonfiguration) =>
            Create(trackСonfiguration);

        public void DeleteTrackСonfiguration(TrackСonfiguration trackСonfiguration) =>
            Delete(trackСonfiguration);

        public async Task<IEnumerable<TrackСonfiguration>> GetAllTrackСonfigurationAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<TrackСonfiguration> GetTrackСonfigurationAsync(Guid trackСonfigurationId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(trackСonfigurationId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
