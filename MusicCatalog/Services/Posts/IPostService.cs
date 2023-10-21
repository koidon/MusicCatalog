using MusicCatalog.Dtos.Post;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Posts;

public interface IPostService
{
    Task<CreatePostDto> CreatePost(CreatePostDto post);
    Task<GetPostDto> GetPostById(int id);

    Task<IEnumerable<GetPostDto>> GetPostsById(int communityId);
    
    Task<List<GetPostDto>> DeletePost(int postId);

    Task UpdatePost(UpdatePostDto post);
    Task<int> GetVoteCount(int postId);
    Task<bool> LikePost(int postId);

}