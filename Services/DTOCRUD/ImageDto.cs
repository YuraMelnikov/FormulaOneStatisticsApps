using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record ImageDto : EntityDto
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
    }
}
