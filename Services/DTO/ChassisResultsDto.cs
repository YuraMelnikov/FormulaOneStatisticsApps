namespace Services.DTO
{
    public record ChassisResultsDto
    {
        public int Season { get; set; }
        public IEnumerable<ConstructorChampColumnDto> Result { get; set; }
    }
}
