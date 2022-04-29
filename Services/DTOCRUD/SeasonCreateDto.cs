using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record SeasonCreateDto : EntityDto
    {
        public int Year { get; set; }
    }
}
