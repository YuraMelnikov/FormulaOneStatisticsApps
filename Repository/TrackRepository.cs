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
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTrack(Track track) =>
            Create(track);

        public void DeleteTrack(Track track) =>
            Delete(track);

        public async Task<IEnumerable<Track>> GetAllTrackAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Track> GetTrackAsync(Guid trackId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(trackId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
