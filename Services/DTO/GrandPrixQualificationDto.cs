namespace Services.DTO
{
    public record GrandPrixQualificationDto
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public Guid IdRacer { get; set; }
        public string Racer { get; set; }
        public Guid IdChassis { get; set; }
        public string Chassis { get; set; }
        public Guid IdEngine { get; set; }
        public string Engine { get; set; }
        public string Time { get; set; }
        public string Gap { get; set; }
        public string IsUpdate { get; set; }
    }
}
