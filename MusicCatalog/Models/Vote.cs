using Microsoft.EntityFrameworkCore;

namespace MusicCatalog.Models;
[Index(nameof(UserId), nameof(PostId))]

public class Vote
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    
    public int PostId { get; set; }

    public AppUser User { get; set; } = null!;

    public Post Post { get; set; } = null!;
}