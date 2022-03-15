using System;

namespace Entities.DataTransferObjects
{
    public record TeamNameCreateDto
    {
        public Guid IdSeasonStart { get; set; }
        public Guid IdSeasonFinish { get; set; }
        public string LongName { get; set; }
    }
}
