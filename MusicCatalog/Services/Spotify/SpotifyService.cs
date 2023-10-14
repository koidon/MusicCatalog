using System.Net.Http.Headers;
using System.Text.Json;
using MusicCatalog.Models;
using MusicCatalog.Models.Albums;
using Album = MusicCatalog.Models.Albums.Album;

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



        return responseObject?.Tracks?.Items?.Select(item => new Song
        {
            Id = item.Track?.Id,
            TrackName = item.Track?.Name ?? "",
            AlbumName = item.Track?.Album?.Name ?? "",
            AlbumId = item.Track?.Album?.Id,
            Artists = string.Join(", ", item.Track?.Artists?.Select(artist => artist.Name) ?? Enumerable.Empty<string>()),
            Popularity = item.Track?.Popularity.ToString() ?? "",
            ImageUrl = item.Track?.Album?.Images?[0].Url ?? ""
        }) ?? Enumerable.Empty<Song>();
    }

    public async Task<Song> GetSongById(string songId, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/tracks/{songId}");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetSong>(responseStream);

        var song = new Song
        {
            Id = responseObject?.Id ?? "",
            TrackName = responseObject?.Name ?? "",
            AlbumName = responseObject?.Album?.Name ?? "",
            Artists = string.Join(", ", responseObject?.Artists?.Select(artist => artist.Name) ?? Enumerable.Empty<string>()),
            Popularity = responseObject?.Popularity.ToString() ?? "",
            ImageUrl = responseObject?.Album?.Images?[0].Url ?? ""
        };

        return song;
    }

    public async Task<Album> GetAlbumById(string albumId, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/albums/{albumId}");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetAlbum>(responseStream);

        var album = new Album
        {
            Id = responseObject?.Id ?? "",
            AlbumType = responseObject?.AlbumType,
            TotalTracks = responseObject?.TotalTracks,
            AlbumName = responseObject?.Name,
            ReleaseDate = responseObject?.ReleaseDate,
            Songs = responseObject?.Tracks?.Items,
            Artists = string.Join(", ", responseObject?.Artists?.Select(artist => artist.Name) ?? Enumerable.Empty<string>()),
            Popularity = responseObject?.Popularity,
            Gennres = string.Join(", ", responseObject?.Genres ?? Enumerable.Empty<string>()),
            ImageUrl = responseObject?.Images?[0].Url
        };

        return album;
    }
}