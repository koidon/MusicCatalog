using MusicCatalog.Models;

namespace MusicCatalog.Services.Spotify;

public interface ISpotifyService
{
    Task<IEnumerable<Playlist>> GetPlaylist(string playlistId, string fields, string accessToken);
}