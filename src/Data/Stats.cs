namespace YandexMusicStats.Data;

public record Stats
{
    public required int AverageDuration { get; init; }
    public required int AverageLikes { get; init; }
    public required int AverageYear { get; init; }
    public required float BestPrecentage { get; init; }
    public required Dictionary<string, float> CountryBreakdown { get; init; }
    public required Dictionary<string, float> GenreBreakdown { get; init; }
    public required int TrackCount { get; init; }
}