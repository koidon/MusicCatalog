using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Dtos.Post;

public class GetPostDto
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string UserId { get; set; } = null!;

    public string title { get; set; } = null!;

    public string content { get; set; } = null!;
    
    public int image_id { get; set; }

    public int vote_count { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public IdentityUser User { get; set; } = null!;
}