namespace Repository.DTO.Common
{
    public class CardItemDto : EntityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string ImageLink { get; set; }
    }
}
