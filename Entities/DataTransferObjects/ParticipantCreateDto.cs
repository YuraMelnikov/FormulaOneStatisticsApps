using System;

namespace Entities.DataTransferObjects
{
    public record ParticipantCreateDto
    {
        public Guid IdGp { get; set; }
        public string Num { get; set; }
        public Guid IdTeam { get; set; }
        public Guid IdChassi { get; set; }
        public Guid IdEngine { get; set; }
        public Guid IdRacer { get; set; }
        public Guid IdTyre { get; set; }
    }
}
