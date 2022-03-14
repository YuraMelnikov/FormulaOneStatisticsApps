using System;

namespace Entities.DataTransferObjects
{
    public class QualificationDto
    {
        public Guid Id { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public ParticipantDto ParticipantDto { get; set; }
    }
}
