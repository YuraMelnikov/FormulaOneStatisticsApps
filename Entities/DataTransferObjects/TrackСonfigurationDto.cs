using System;

namespace Entities.DataTransferObjects
{
    public class TrackСonfigurationDto
    {
        public Guid Id { get; set; }
        public float Length { get; set; }
        public string Name { get; set; }
        public ImageDto ImageDto { get; set; }
        public TrackDto TrackDto { get; set; }
    }
}
