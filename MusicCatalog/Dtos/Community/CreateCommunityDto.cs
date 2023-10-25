using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Community;

public class CreateCommunityDto
{
    [MaxLength(255, ErrorMessage = "Titeln får  inte vara längre än 255 karaktärer")]
    public string Name { get; set; } = null!;
}