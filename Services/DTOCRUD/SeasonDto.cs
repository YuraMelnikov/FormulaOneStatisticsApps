using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record SeasonDto : EntityDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string? Link { get; set; }
    }
}
