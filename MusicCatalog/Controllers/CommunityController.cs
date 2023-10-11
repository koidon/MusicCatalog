/*using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Community;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Communities;

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
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCommunity(CreateCommunityDto community)
    {
        try
        {
            if (!ModelState.IsValid)
                ViewComponent("CreateCommunity");


            await _communityService.CreateCommunity(community);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle skapas");
        }

        return RedirectToAction("Release", new community);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeleteCommunity(int communityId)
    {
        var community = await GetCommunityDto();

        var response = await _communityService.DeleteCommunity(communityId);
        if (response is null)
        {
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle tas bort");
        }
        else
        {
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Success, "Community har tagits bort");
        }

        return View("Release");
    }
}*/