namespace Services.DTO
{
    public record RacerTeamsAndChassies
    {
        public Guid IdChassis { get; set; }
        public string Chassis { get; set; }
    }
}
