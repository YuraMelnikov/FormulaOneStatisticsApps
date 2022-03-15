using System;

namespace Entities.DataTransferObjects
{
    public record DescriptionGPResultCreateDto
    {
        public Guid IdGpResult { get; set; }
        public string Description { get; set; }
    }
}
