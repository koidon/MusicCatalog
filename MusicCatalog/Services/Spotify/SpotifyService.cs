using System.Net.Http.Headers;
using System.Text.Json;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Spotify;

public class SpotifyService : ISpotifyService
{
    private readonly HttpClient _httpClient;


    public SpotifyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Song>> GetPlaylist(string playlistId, string fields, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/playlists/{playlistId}?fields={fields}?");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetPlaylist>(responseStream);

        return responseObject?.tracks?.items.Select(item => new Song
        {
            TrackName = item.track.name,
            AlbumName = item.track.album.name,
            Artists = string.Join(", ", item.track.artists.Select(artist => artist.name)),
            Popularity = item.track.popularity.ToString(),
            ImageUrl = item.track.album.images[1].url
        });
    }
}