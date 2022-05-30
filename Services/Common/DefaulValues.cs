namespace Services.Common
{
    public static class DefaulValues
    {
        public static string DefaultImage { get; } = "/assets/img/empty.jpg";
        public static int MinimumSeasonYear { get; } = 1950;
        public static Guid TypeStartField { get; } = Guid.Parse("d5e71263-4cc5-4963-bbf5-53dff96ef00c");
    }
}
