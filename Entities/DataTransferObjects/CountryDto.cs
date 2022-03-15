using System;

namespace Entities.DataTransferObjects
{
    public record CountryDto
    {
        public Guid Id;
        public string Name { get; set; }
        public ImageDto Image { get; set; }
    }
}
