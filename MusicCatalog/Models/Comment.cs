using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Models;

public class Comment
{

    public const int MinContentLength = 3;
    public const int MaxContentLength = 255;

    public int Id { get; set; }

    public int ReviewId { get; set; }

    public string UserId { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;

    public string content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Review Review { get; set; } = null!;
}