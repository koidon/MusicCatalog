using Microsoft.AspNetCore.Identity;
using MusicCatalog.Services.Communities;
using MusicCatalog.Services.Posts;

namespace MusicCatalog.Controllers;

public class CommunityController
{
    private readonly ICommunityService _communityService;
    private readonly UserManager<IdentityUser> _userManager;

    public CommunityController( ICommunityService communityService, UserManager<IdentityUser> userManager)
    {
        _communityService = communityService;
        _userManager = userManager;
    }
}