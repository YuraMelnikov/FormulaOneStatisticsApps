using System;

namespace Entities.DataTransferObjects
{
    public class DescriptionGPResultUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdGpResult { get; set; }
        public string Description { get; set; }
    }
}
