namespace Services.DTO
{
    public record RacerTeamsAndChassies
    {
        public Guid IdChassies { get; set; }
        public string Chassies { get; set; }
        public string LiveryLink { get; set; }
    }
}
