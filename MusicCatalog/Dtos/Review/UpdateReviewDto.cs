using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Review;

public class UpdateReviewDto
{
    public int Id { get; set; }

    public string SongId { get; set; } = null!;

    [Required (ErrorMessage = "Rutan får inte lämnas tom")]
    public string Content { get; set; } = null!;
}