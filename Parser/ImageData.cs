namespace Parser
{
    public class ImageData
    {
        public Guid IdSeason { get; set; }
        public Guid IdGrandPrix { get; set; }
        public List<Guid> Racers { get; set; }
        public string OldLink { get; set; }
        public string NewLink { get; set; }
    }
}
