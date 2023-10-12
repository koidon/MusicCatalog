namespace MusicCatalog.Models;

public class Community
{
    public const int MinContentLength = 3;
    public const int MaxContentLength = 55;
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<Post> Posts { get; set; } = null!;
}