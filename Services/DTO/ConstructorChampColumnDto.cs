namespace Services.DTO
{
    public record ConstructorChampColumnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Position { get; set; }
    }
}
