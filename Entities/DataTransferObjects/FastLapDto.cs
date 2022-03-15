using System;

namespace Entities.DataTransferObjects
{
    public record FastLapDto
    {
        public Guid Id { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public GPResultDto GPResultDto { get; set; }
    }
}
