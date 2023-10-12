using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Post;

public class CreatePostDto
{
    public string CommunityId { get; set; } = null!;
    [Required (ErrorMessage = "Rutan får inte lämnas tom")]
    public string Title { get; set; } = null!;
    [Required (ErrorMessage = "Rutan får inte lämnas tom")]
    public string Content { get; set; } = null!;
}