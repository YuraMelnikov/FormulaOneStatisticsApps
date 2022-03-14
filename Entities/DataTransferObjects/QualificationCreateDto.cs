using System;

namespace Entities.DataTransferObjects
{
    public class QualificationCreateDto
    {
        public Guid IdParticipant { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
    }
}
