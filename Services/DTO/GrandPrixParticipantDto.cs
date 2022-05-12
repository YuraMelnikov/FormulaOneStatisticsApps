namespace Services.DTO
{
    public record GrandPrixParticipantDto
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public string TeamName { get; set; }
        public Guid IdChassis { get; set; }
        public string Chassis { get; set; }
        public Guid IdEngine { get; set; }
        public string Engine { get; set; }
        public Guid IdTyre { get; set; }
        public string Tyre { get; set; }
        public Guid IdRacer { get; set; }
        public string Racer { get; set; }
        public string Constructor { get; set; }
    }
}
