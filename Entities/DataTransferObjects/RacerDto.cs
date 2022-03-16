namespace Entities.DataTransferObjects
{
    public record RacerDto
    {
        public Guid Id { get; set; }
        public string SecondName { get; set; }
        public string ImageLink { get; set; }
    }
}
