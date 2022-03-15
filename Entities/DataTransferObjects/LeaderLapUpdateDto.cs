using System;

namespace Entities.DataTransferObjects
{
    public record LeaderLapUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdGpResult { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
    }
}
