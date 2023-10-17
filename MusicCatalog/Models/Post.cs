using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Models;

public class Post
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    [MaxLength(255)]
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? VoteCount { get; set; }
    
    public int CommunityId { get; set; }

    public Community Community { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public AppUser User { get; set; } = null!;

    public List<Vote> Votes { get; } = new();
}