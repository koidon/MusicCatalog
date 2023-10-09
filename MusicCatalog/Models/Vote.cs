namespace MusicCatalog.Models;

public class Vote
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int PostId { get; set; }
    
    public int VoteCount { get; set; }
}