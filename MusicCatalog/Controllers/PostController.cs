using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicCatalog.Dtos.Post;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Posts;

namespace MusicCatalog.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly IMemoryCache _memoryCache;

    public PostController(IPostService postService, IMemoryCache memoryCache)
    {
        _postService = postService;
        _memoryCache = memoryCache;
    }
    [HttpGet]
    [Authorize]
    public IActionResult CreatePost()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost(CreatePostDto post)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _postService.CreatePost(post);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Inlägget har skapats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle skapas");
        }

        return RedirectToAction("AllPosts");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeletePost(int postId)
    {
        try
        {
            await _postService.DeletePost(postId);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Inlägget har tagits bort");
            
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle tas bort");
        }

        return RedirectToAction("AllPosts");
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> UpdatePost(int id)
    {
        try
        {
            var post = await _postService.GetPostById(id);
            return View(post);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle hämtas");
        }

        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdatePost(UpdatePostDto post)
    {
        try
        {
            if (!ModelState.IsValid)
                return View();

            await _postService.UpdatePost(post);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Inlägget har uppdaterats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle uppdateras");
        }

        return RedirectToAction("AllPosts");
    }
    [HttpGet]
    public async Task<IActionResult> AllPosts(int communityId, string searchQuery)
    {
        try
        {
            var posts = await _postService.GetPostsById(communityId);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                posts = posts.Where(p =>
                    p.Title.ToLower().Contains(searchQuery) ||
                    p.Content.ToLower().Contains(searchQuery)
                ).ToList();
            }

            // Count and cache vote counts
            if (!_memoryCache.TryGetValue("VoteCounts", out Dictionary<int, int>? cachedVoteCounts))
            {
                cachedVoteCounts = new Dictionary<int, int>();

                if (posts != null)
                {
                    foreach (var post in posts)
                    {
                        var count = await _postService.GetVoteCount(post.Id);
                        cachedVoteCounts[post.Id] = count;
                    }
                }

                _memoryCache.Set("VoteCounts", cachedVoteCounts, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }

            // Update the post view model with vote counts
            foreach (var post in posts)
            {
                if (cachedVoteCounts.TryGetValue(post.Id, out int voteCount))
                {
                    post.VoteCount = voteCount;
                }
            }

            return View(posts);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägg skulle hämtas");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ViewPost(int postId)
    {
        try
        {
            var post = await _postService.GetPostById(postId);
            if (post.Id == 0)
            {
                TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Post not found");
                //return RedirectToAction("AllPosts", new { communityId = post.CommunityId });
            }
            return View(post);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägg skulle hämtas");
        }

        return RedirectToAction("AllPosts"); // Redirect to the post list or another appropriate action
    }
    
}