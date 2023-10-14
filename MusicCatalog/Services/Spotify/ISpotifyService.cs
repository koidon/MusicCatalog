using MusicCatalog.Models;
using MusicCatalog.Models.Artist;
using Album = MusicCatalog.Models.Albums.Album;

namespace MusicCatalog.Services.Spotify;

public interface ISpotifyService
{
    Task<IEnumerable<Song>> GetPlaylist(string playlistId, string fields, string accessToken);

    Task<Song> GetSongById(string songId, string accessToken);

    Task<Album> GetAlbumById(string albumId, string accessToken);

    Task<Artist> GetArtistById(string artistId, string accessToken);

    Task<ArtistAlbums> GetArtistAlbumsById(string artistId, string accessToken);
}