namespace MusicCatalog.Models;

public class Review
{



    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string SongId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public AppUser User { get; set; } = null!;

    public ICollection<ReviewComment>? Comments { get; set; }

}

