using System;

namespace Entities.DataTransferObjects
{
    public class ImageDto
    {
        public Guid Id;
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
