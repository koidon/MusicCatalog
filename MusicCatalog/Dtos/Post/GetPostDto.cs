using Microsoft.AspNetCore.Identity;
using MusicCatalog.Models;

namespace MusicCatalog.Dtos.Post;

public class GetPostDto
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string UserId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;
    
    public int CommunityId { get; set; }
    
    public int ImageId { get; set; }

    public int VoteCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public AppUser User { get; set; } = null!;
}