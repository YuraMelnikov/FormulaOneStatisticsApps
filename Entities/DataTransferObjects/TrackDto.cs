using System;

namespace Entities.DataTransferObjects
{
    public class TrackDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CountryDto CountryDto { get; set; }
        public ImageDto ImagedDto { get; set; }
    }
}
