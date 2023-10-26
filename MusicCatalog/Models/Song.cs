using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalog.Models;

[NotMapped]
public class Song
{
    public string? Id { get; set; }
    public string? TrackName { get; set; }
    public string? AlbumName { get; set; }
    public string? AlbumId { get; set; }
    public string? Artists { get; set; }

    public string? ArtistId { get; set; }
    public int? Popularity { get; set; }
    public string? ImageUrl { get; set; }

    public string? ReleaseDate { get; set; }
}