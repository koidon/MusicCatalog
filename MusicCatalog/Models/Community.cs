namespace MusicCatalog.Models;

public class Community
{
    public const int MinContentLength = 3;
    public const int MaxContentLength = 55;
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public string Name { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}