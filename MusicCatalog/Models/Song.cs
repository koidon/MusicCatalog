using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalog.Models;

[NotMapped]
public class Song
{
    public string? Id { get; set; }
    public string? TrackName { get; set; }
    public string? AlbumName { get; set; }
    public string? Artists { get; set; }
    public string? Popularity { get; set; }
    public string? ImageUrl { get; set; }
}