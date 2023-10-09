using Microsoft.AspNetCore.Identity;
using MusicCatalog.Services.Posts;
using MusicCatalog.Services.Reviews;

namespace MusicCatalog.Controllers;

public class PostController
{
    private readonly IPostService _postService;
    private readonly UserManager<IdentityUser> _userManager;

    public PostController( IPostService postService, UserManager<IdentityUser> userManager)
    {
        _postService = postService;
        _userManager = userManager;
    }
}