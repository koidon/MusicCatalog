using MusicCatalog.Dtos.Post;

namespace MusicCatalog.ViewModels;

public class PostCommunityIdViewModel
{
    public IEnumerable<GetPostDto> Posts { get; set; }

    public int CommunityId { get; set; }
    
}