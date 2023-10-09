using MusicCatalog.Models;

namespace MusicCatalog.Dtos.Spotify;

[Serializable]
public class PlaylistCookie
{
    public List<Song> Songs { get; set; }
}