
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Data;
using MusicCatalog.Dtos.Post;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Posts;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    private string GetUserId() => _httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!;

    public async Task<CreatePostDto> CreatePost(CreatePostDto newPost)
    {
        var post = _mapper.Map<Post>(newPost);
        post.AppUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();

        return newPost;
    }
}

/*
public async Task<IEnumerable<GetPostDto>> GetPostsById(int communityId)
{
    var dbPosts = await _dbContext.Posts
        .Include(p => p.AppUser)
        .Where(p => communityId.Contains(p.CommunityId))
        .ToListAsync();

    var posts = dbPosts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();

    return posts;
}

public async Task<List<GetPostDto>> DeletePost(int postId)
{
    var posts = new List<GetPostDto>();

    try
    {
        var dbPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId && p.User!.Id == GetUserId());
        if (dbPost is null)
            throw new Exception($"Post with Id '{postId}' not found.");

        _dbContext.Posts.Remove(dbPost);
        await _dbContext.SaveChangesAsync();

        posts = await _dbContext.Posts.Where(p => p.User.Id == GetUserId())
            .Select(p => _mapper.Map<GetPostDto>(p)).ToListAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }

    return posts;
}

public Post GetPost(int postId)
{
    if (_dbContext.Posts.Find(postId) is Post post)
    {
        return post;
    }

    return null;
}
}
*/

