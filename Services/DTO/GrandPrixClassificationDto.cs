namespace Services.DTO
{
    public record GrandPrixClassificationDto
    {
        public string Position { get; set; }
        public Guid IdRacer { get; set; }
        public string Racer { get; set; }
        public Guid IdChassis { get; set; }
        public string Chassis { get; set; }
        public string Circles { get; set; }
        public string Time { get; set; }
        public string AvrSpeed { get; set; }
        public string Points { get; set; }
        public string Note { get; set; }
    }
}
