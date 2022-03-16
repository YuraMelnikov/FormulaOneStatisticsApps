namespace Entities.DataTransferObjects
{
    public record SeasonDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string ImageLink { get; set; }
    }
}
