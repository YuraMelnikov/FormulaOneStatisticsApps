using Services.DTO.Common;

namespace Services.DTO
{
    public record TrackConfigurationDto
    {
        public string Image { get; set; }
        public float Length { get; set;  }
        public IEnumerable<LabelItemWhisId> Seasons { get; set; }
    }
}
