namespace Entities.DataTransferObjects
{
    public record ManufacturerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
    }
}
