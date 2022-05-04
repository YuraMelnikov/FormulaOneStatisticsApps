using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record  CountryDto : EntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
