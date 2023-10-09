using MusicCatalog.Models;

namespace MusicCatalog.Services.Spotify;

public interface ISpotifyService
{
    Task<IEnumerable<Song>> GetPlaylist(string playlistId, string fields, string accessToken);

    Task<Song> GetSongById(string songId, string accessToken);
}