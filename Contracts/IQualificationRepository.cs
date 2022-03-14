using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQualificationRepository 
    {
        Task<IEnumerable<Qualification>> GetAllQualificationAsync(bool trackChanges);
        Task<Qualification> GetQualificationAsync(Guid qualificationId, bool trackChanges);
        void CreateQualification(Qualification qualification);
        void DeleteQualification(Qualification qualification);
    }
}
