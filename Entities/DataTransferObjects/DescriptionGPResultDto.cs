using System;

namespace Entities.DataTransferObjects
{
    public class DescriptionGPResultDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public GPResultDto GPResultDto { get; set; }
    }
}
