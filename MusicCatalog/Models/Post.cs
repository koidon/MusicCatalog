namespace MusicCatalog.Models;

public class Post
{
    public const int MinContentLength = 3;
    public const int MaxContentLength = 255;
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? VoteCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public AppUser AppUser { get; set; } = null!;

    public List<Vote> Votes { get; } = new();
}