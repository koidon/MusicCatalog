namespace MusicCatalog.Dtos.Community;

public class CreateCommunityDto
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;
}