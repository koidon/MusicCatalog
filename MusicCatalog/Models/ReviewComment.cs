namespace MusicCatalog.Models;

public class ReviewComment
{

    public const int MinContentLength = 3;
    public const int MaxContentLength = 255;

    public int Id { get; set; }

    public int ReviewId { get; set; }

    public string UserId { get; set; } = null!;

    public AppUser User { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Review Review { get; set; } = null!;
}