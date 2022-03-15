using System;

namespace Entities.DataTransferObjects
{
    public record SeasonDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public ImageDto ImageDto { get; set; }
        public TypeCalculateDto TypeCalculateDto { get; set; }
    }
}
