using System;

namespace Entities.DataTransferObjects
{
    public record TeamDto
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public CountryDto CountryDto { get; set; }
        public ImageDto ImageDto { get; set; }
    }
}
