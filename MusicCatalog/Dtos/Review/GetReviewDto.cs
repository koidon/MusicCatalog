using System.ComponentModel.DataAnnotations;
using MusicCatalog.Models;
using DateTime = System.DateTime;

namespace MusicCatalog.Dtos.Review;

public class GetReviewDto
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string SongId { get; set; } = null!;

    [Required (ErrorMessage = "Rutan får inte lämnas tom")]
    [MaxLength(3000, ErrorMessage = "Texten får  inte var längre än 3000 karaktärer")]
    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public AppUser User { get; set; } = null!;

}