using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Post;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Posts;

namespace MusicCatalog.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly UserManager<IdentityUser> _userManager;

    public PostController(IPostService postService, UserManager<IdentityUser> userManager)
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
            {
                // Redirect till CreatePost vyn
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

        return RedirectToAction("");
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

        return RedirectToAction("");
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

        return RedirectToAction(""); // Redirect to an appropriate action
    }
}