using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalog.Models.Albums;
[NotMapped]
public class Album
{
    public string? Id { get; set; }
    public string? AlbumType { get; set; }
    public int? TotalTracks { get; set; }
    public string? AlbumName { get; set; }
    public string? ReleaseDate { get; set; }
    public Items[]? Songs { get; set; }
    public string? Artists { get; set; }
    public int? Popularity { get; set; }
    public string? Genres { get; set; }
    public string? ImageUrl { get; set; }
}