using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Dtos.Review;

public class GetReviewDto
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string SongId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public IdentityUser User { get; set; } = null!;

}