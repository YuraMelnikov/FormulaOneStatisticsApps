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
    public class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {
        public ParticipantRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateParticipant(Participant participant) =>
            Create(participant);

        public void DeleteParticipant(Participant participant) =>
            Delete(participant);

        public async Task<IEnumerable<Participant>> GetAllParticipantAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Participant> GetParticipantAsync(Guid participantId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(participantId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
