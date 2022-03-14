using System;

namespace Entities.DataTransferObjects
{
    public class TrackСonfigurationUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdTrack { get; set; }
        public Guid IdImage { get; set; }
        public float Length { get; set; }
        public string Name { get; set; }
    }
}
