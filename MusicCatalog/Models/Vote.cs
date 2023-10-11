using Microsoft.EntityFrameworkCore;

namespace MusicCatalog.Models;
[Index(nameof(UserId), nameof(PostId))]

public class Vote
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int PostId { get; set; }

    public AppUser User { get; set; } = null!;

    public Post Post { get; set; } = null!;
}