using System;

namespace Entities.DataTransferObjects
{
    public record TeamNameUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdSeasonStart { get; set; }
        public Guid IdSeasonFinish { get; set; }
        public string LongName { get; set; }
    }
}
