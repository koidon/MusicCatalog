using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Community;

public class UpdateCommunityDto
{
    public int Id { get; set; }

    [Required (ErrorMessage = "Rutan får inte lämnas tom")]
    [MaxLength(3000, ErrorMessage = "Texten får  inte vara längre än 3000 karaktärer")]
    public string Name { get; set; } = null!;
}
