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
        post.User = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();

        return newPost;
    }

    public async Task<IEnumerable<GetPostDto>> GetPostsById(int communityId)
    {
        var dbPosts = await _dbContext.Posts
            .Include(p => p.User)
            .Where(p => communityId == (p.CommunityId))
            .ToListAsync();

        var posts = dbPosts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();

        return posts;
    }

    public async Task<List<GetPostDto>> DeletePost(int postId)
    {


            var dbPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId && p.User!.Id == GetUserId());
            if (dbPost is null)
                throw new Exception($"Post with Id '{postId}' not found.");

            _dbContext.Posts.Remove(dbPost);
            await _dbContext.SaveChangesAsync();

            var posts = await _dbContext.Posts.Where(p => p.User.Id == GetUserId())
                .Select(p => _mapper.Map<GetPostDto>(p)).ToListAsync();


        return posts;
    }

    public async Task<GetPostDto> GetPostById(int postId)
    {
        var dbPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);

        if (dbPost is null)
            return new GetPostDto();

        var postDto = _mapper.Map<GetPostDto>(dbPost);
        return postDto;
    }
    public async Task UpdatePost(UpdatePostDto updatedPost)
    {
        var post =
            await _dbContext.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == updatedPost.Id && p.User.Id == GetUserId()) ??
            throw new Exception($"Post with Id '{updatedPost.Id}' not found.");

        _mapper.Map(updatedPost, post);

        post.UpdatedAt = DateTime.Now;

        _dbContext.Update(post);
        await _dbContext.SaveChangesAsync();
    }
    // Votes ta med postId som parameter och counta mot databasen
}





