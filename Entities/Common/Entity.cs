﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Common
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
