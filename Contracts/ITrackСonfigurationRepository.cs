using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrackСonfigurationRepository
    {
        Task<IEnumerable<TrackСonfiguration>> GetAllTrackСonfigurationAsync(bool trackChanges);
        Task<TrackСonfiguration> GetTrackСonfigurationAsync(Guid trackСonfigurationId, bool trackChanges);
        void CreateTrackСonfiguration(TrackСonfiguration trackСonfiguration);
        void DeleteTrackСonfiguration(TrackСonfiguration trackСonfiguration);
    }
}
