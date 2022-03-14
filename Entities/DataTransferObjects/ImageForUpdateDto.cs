using System;

namespace Entities.DataTransferObjects
{
    public class ImageForUpdateDto
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
