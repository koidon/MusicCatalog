using MusicCatalog.Models;

namespace MusicCatalog.Dtos.Community;

public class GetCommunityDto
{
    public int Id { get; set; }
    
    public string UserId { get; set; }

    public string Name { get; set; } = null!;
    
    public AppUser User { get; set; } = null!;
}