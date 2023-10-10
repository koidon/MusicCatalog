namespace MusicCatalog.Dtos.Community;

public class GetCommunityDto
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public string Name { get; set; } = null!;
}