using System;

namespace Entities.DataTransferObjects
{
    public record FastLapUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdGpResult { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
    }
}
