using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Post;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Posts;

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
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost(CreatePostDto post)
    {
        try
        {
            if (!ModelState.IsValid)
                ViewComponent("CreateReview");


            await _postService.CreatePost(post);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle skapas");
        }

        return RedirectToAction("Release");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeletePost(int postId)
    {
        var post = await GetPost(postId);

        var response = await _postService.DeletePost(postId);
        if (response is null)
        {
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när inlägget skulle tas bort");
        }
        else
        {
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Success, "Inlägget har tagits bort");
        }

        return View("Release");
    }
}