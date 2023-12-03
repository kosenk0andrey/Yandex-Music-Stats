using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Track;
using YandexMusicStats.Data;

namespace YandexMusicStats.Services;

public class DataProcessor
{
    public Stats GetStats(YLoginInfo loginInfo, List<YTrack> trackList)
    {
        return new Stats
        {
            AvatarUrl = loginInfo.AvatarUrl,
            Email = loginInfo.DefaultEmail,
            UserName = loginInfo.DisplayName,

            AverageDuration = (int)trackList.Select(t => t.DurationMs).Average(),
            AverageLikes = (int)trackList.Where(t => t.Albums?.Any() == true).Select(t => t.Albums[0].LikesCount).Average(),
            AverageYear = (int)trackList.Where(t => t.Albums?.Any() == true).Select(t => t.Albums[0].Year).Average(),
            BestPrecentage = (float)trackList.Where(t => t.Best.Equals(true)).Count() / trackList.Count,
            CountryBreakdown = trackList.Where(t => t.Artists?.Any() == true && t.Artists[0].Countries?.Any() == true).GroupBy(t => t.Artists[0].Countries[0]).ToDictionary(k => k.Key, v => (float)v.Count() / trackList.Count),
            GenreBreakdown = trackList.Where(t => t.Albums?.Any() == true).GroupBy(t => t.Albums[0].Genre).ToDictionary(k => k.Key, v => (float)v.Count() / trackList.Count),
            TrackCount = trackList.Count
        };
    }
}
