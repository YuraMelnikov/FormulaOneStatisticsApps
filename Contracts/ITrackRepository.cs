using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllTrackAsync(bool trackChanges);
        Task<Track> GetTrackAsync(Guid trackId, bool trackChanges);
        void CreateTrack(Track track);
        void DeleteTrack(Track track);
    }
}
