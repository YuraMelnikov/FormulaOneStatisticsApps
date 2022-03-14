using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class EntityId
    {
        [Key]
        public Guid Id { get; set; }

        public EntityId()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
