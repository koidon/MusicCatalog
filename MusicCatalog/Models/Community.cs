namespace MusicCatalog.Models;

public class Community
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public string Name { get; set; } = null!;
}