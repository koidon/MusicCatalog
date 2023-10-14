using System.Net.Http.Headers;
using System.Text.Json;
using MusicCatalog.Models;
using MusicCatalog.Models.Albums;
using MusicCatalog.Models.Artist;
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
            ArtistId = item.Track?.Artists?[0].Id,
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
            Genres = string.Join(", ", responseObject?.Genres ?? Enumerable.Empty<string>()),
            ImageUrl = responseObject?.Images?[0].Url
        };

        return album;
    }

    public async Task<Artist> GetArtistById(string artistId, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{artistId}");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetArtist>(responseStream);

        var artist = new Artist
        {
            Id = responseObject?.Id ?? "",
            Genres = string.Join(", ", responseObject?.Genres ?? Enumerable.Empty<string>()),
            ImageUrl = responseObject?.Images?[0].Url,
            ArtistName = responseObject?.Name,
            Popularity = responseObject?.Popularity
        };

        return artist;
    }

    public async Task<ArtistAlbums> GetArtistAlbumsById(string artistId, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{artistId}/albums");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetArtistAlbums>(responseStream);

        var artistAlbums = new ArtistAlbums
        {
            Albums = responseObject?.Items
        };

        return artistAlbums;
    }

    /*public async Task<Artist> GetArtistById(string artistId, string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{artistId}/albums");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseObject = await JsonSerializer.DeserializeAsync<GetArtist>(responseStream);

        var artist = new Artist
        {
            Id = responseObject?.Items[0].Artists. ?? "",
            Artists = string.Join(", ", responseObject?.?.Select(artist => artist.Name) ?? Enumerable.Empty<string>()),
            Popularity = responseObject?.Popularity,
            Genres = string.Join(", ", responseObject?.Genres ?? Enumerable.Empty<string>()),
            ImageUrl = responseObject?.Images?[0].Url
        };

        return album;
    }*/
}