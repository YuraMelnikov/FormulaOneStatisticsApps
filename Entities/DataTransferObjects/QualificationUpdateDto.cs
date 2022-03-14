using System;

namespace Entities.DataTransferObjects
{
    public class QualificationUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdParticipant { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
    }
}
