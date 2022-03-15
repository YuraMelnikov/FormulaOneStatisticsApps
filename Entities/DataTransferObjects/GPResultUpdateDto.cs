using System;

namespace Entities.DataTransferObjects
{
    public record GPResultUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdParticipant { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public Guid IdTypeFinish { get; set; }
        public int Lap { get; set; }
    }
}
