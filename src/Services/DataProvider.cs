using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Client;

namespace YandexMusicStats.Services;

public class DataProvider
{
    public async Task<YLoginInfo?> GetUserInfoAsync(string ymToken)
    {
        var client = new YandexMusicClientAsync();

        if (await client.Authorize(ymToken))
            return await client.GetLoginInfo();

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
