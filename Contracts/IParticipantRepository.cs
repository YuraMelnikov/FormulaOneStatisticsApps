using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllParticipantAsync(bool trackChanges);
        Task<Participant> GetParticipantAsync(Guid participantId, bool trackChanges);
        void CreateParticipant(Participant participant);
        void DeleteParticipant(Participant participant);
    }
}
