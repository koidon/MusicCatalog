using MusicCatalog.Dtos.Post;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Posts;

public interface IPostService
{
    Task<CreatePostDto> CreatePost(CreatePostDto post);
    Task<GetPostDto> GetPost(int id);

    Task<IEnumerable<GetPostDto>> GetPostsById(string communityId);
    
    Task<List<GetPostDto>> DeletePost(int postId);
}