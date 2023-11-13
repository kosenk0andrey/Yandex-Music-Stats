using Yandex.Music.Api.Models.Track;
using Yandex.Music.Client;

namespace YandexMusicStats.Services;

public class DataProvider
{
    public List<YTrack>? GetLikedTracks(string ymToken)
    {
        var client = new YandexMusicClient();

        if (client.Authorize(ymToken))
            return client.GetLikedTracks();

        return null;
    }
    public async Task<List<YTrack>?> GetLikedTracksAsync(string ymToken)
    {
        var client = new YandexMusicClientAsync();

        if (await client.Authorize(ymToken))
            return await client.GetLikedTracks();

        return null;
    }
}
