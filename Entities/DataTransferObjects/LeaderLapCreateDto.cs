using System;

namespace Entities.DataTransferObjects
{
    public record LeaderLapCreateDto
    {
        public Guid IdGpResult { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
    }
}
