using MusicCatalog.Models.Artist;

namespace MusicCatalog.ViewModels;

public class ArtistAlbumsViewModel
{
    public Artist Artist { get; set; }
    public ArtistAlbums ArtistAlbums { get; set; }

    public List<int> ReviewCount { get; set; }
}