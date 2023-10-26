using MusicCatalog.Dtos.Post;

namespace MusicCatalog.ViewModels;

public class PostCommunityIdViewModel
{
    public required IEnumerable<GetPostDto> Posts { get; set; }

    public int CommunityId { get; set; }
    
}