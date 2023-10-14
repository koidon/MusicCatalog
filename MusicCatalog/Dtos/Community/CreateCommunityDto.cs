using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Community;

public class CreateCommunityDto
{
    public string UserId { get; set; }

    [Range(1, 255, ErrorMessage = "Titeln får inte längre än 255 karaktärer")]
    public string Name { get; set; } = null!;
}