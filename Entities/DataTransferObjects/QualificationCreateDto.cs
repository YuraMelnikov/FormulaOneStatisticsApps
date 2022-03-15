using System;

namespace Entities.DataTransferObjects
{
    public record QualificationCreateDto
    {
        public Guid IdParticipant { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
    }
}
