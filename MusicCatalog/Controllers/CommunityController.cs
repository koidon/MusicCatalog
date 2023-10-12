using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Community;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Communities;

namespace MusicCatalog.Controllers;

public class CommunityController : Controller
{
    private readonly ICommunityService _communityService;

    public CommunityController(ICommunityService communityService)
    {
        _communityService = communityService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCommunity(CreateCommunityDto community)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // Redirect till CreatePost vyn
                //return View();
            }

            await _communityService.CreateCommunity(community);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Community har skapats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle skapas");
        }

        return RedirectToAction("");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeleteCommunity(int communityId)
    {
        try
        {
            var response = await _communityService.DeleteCommunity(communityId);
            if (response is null)
            {
                TempData["Alert"] =
                    AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle tas bort");
            }
            else
            {
                TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Community har tagits bort");
            }
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle tas bort");
        }

        return RedirectToAction(""); // Replace
    }
    [HttpGet]
    public async Task<IActionResult> Communities()
    {
        try
        {
            var communities = await _communityService.GetCommunities();
            return View(communities);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när communities skulle hämtas");
        }

        return View();
    }
    /*public async Task<IActionResult> ViewPosts(int communityId)
    {
        // Retrieve posts for the selected community
        var posts = await _communityService.GetPostsByCommunityId(communityId);

        // Retrieve community name
        var community = await _communityService.GetCommunityName(communityId);

        ViewBag.CommunityName = community.Name;
        ViewBag.CommunityId = community.Id;

        return View();
    }
    [HttpGet]
    [Authorize]
    public IActionResult CreatePost(int communityId)
    {
        ViewBag.CommunityId = communityId;

        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePost(CreatePostDto post)
    {
        // Handle the creation of the post
        // Redirect to the ViewPosts action for the selected community after creation
    }*/
}