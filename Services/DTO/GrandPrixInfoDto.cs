namespace Services.DTO
{
    public record GrandPrixInfoDto
    {
        public string Name { get; set; }
        public string ImgLink { get; set; }
        public string TrackName { get;set; }
        public string ImgTrackLink { get; set; }
        public int NumberInSeason { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Weather { get; set; }
    }
}
