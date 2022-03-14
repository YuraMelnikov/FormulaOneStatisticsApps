using System;

namespace Entities.DataTransferObjects
{
    public class SeasonDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public ImageDto ImageDto { get; set; }
        public TypeCalculateDto TypeCalculateDto { get; set; }
    }
}
