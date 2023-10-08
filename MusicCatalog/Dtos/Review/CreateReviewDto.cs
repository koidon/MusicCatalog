namespace MusicCatalog.Dtos.Review;

public class CreateReviewDto
{

    public string SongId { get; set; } = null!;

    public string Content { get; set; } = null!;
}