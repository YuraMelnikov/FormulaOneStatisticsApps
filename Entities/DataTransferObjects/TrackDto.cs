namespace Entities.DataTransferObjects
{
    public record TrackDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
    }
}
