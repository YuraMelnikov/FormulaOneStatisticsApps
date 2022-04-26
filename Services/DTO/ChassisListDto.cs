using Services.DTO.Common;

namespace Services.DTO
{
    public record ChassisListDto
    {
        public IEnumerable<LabelItemWhisId> Seasons { get; set; }
        public IEnumerable<NameDto> Teams {get;set;}
        public IEnumerable<LabelItemWhisId> Drivers { get; set; }
        public IEnumerable<LabelItemWhisId> Engines { get; set; }
        public IEnumerable<LabelItemWhisId> Tyres { get; set; }
    }
}
