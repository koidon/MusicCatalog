using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Models;

public class Community
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    [MaxLength(255)]
    public string Name { get; set; } = null!;
    
    public AppUser User { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<Post> Posts { get; set; } = null!;
}