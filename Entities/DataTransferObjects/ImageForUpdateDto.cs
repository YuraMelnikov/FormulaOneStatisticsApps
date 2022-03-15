using System;

namespace Entities.DataTransferObjects
{
    public record ImageForUpdateDto
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
