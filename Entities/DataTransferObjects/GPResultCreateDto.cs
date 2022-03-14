using System;

namespace Entities.DataTransferObjects
{
    public class GPResultCreateDto
    {
        public Guid IdParticipant { get; set; }
        public TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public Guid IdTypeFinish { get; set; }
        public int Lap { get; set; }
    }
}
