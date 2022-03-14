using System;

namespace Entities.DataTransferObjects
{
    public class ManufacturerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CountryDto CountryDto { get; set; }
        public ImageDto ImageDto { get; set; }
    }
}
