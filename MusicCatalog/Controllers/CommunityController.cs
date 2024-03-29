using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet]
    [Authorize]
    public IActionResult CreateCommunity()
    {
        return View(); 
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCommunity(CreateCommunityDto community)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _communityService.CreateCommunity(community);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Community har skapats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle skapas");
        }

        return RedirectToAction("Communities");
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeleteCommunity(int communityId)
    {
        try
        {
            await _communityService.DeleteCommunity(communityId);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Community har tagits bort");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle tas bort");
        }

        return RedirectToAction("Communities");
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
    [HttpGet]
    public async Task<IActionResult> ViewCommunity(int communityId)
    {
        try
        {
            var community = await _communityService.GetCommunity(communityId);
            if (community.Id == 0)
            {
                TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Community not found");
                return RedirectToAction("Communities");
            }
            return View(community);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle hämtas");
        }

        return RedirectToAction("Communities");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> UpdateCommunity(int id)
    {
        try
        {
            var community = await _communityService.GetCommunity(id);
            return View(community);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle hämtas för redigering");
        }

        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateCommunity(UpdateCommunityDto updatedCommunity)
    {
        try
        {
            if (!ModelState.IsValid)
                return View();

            await _communityService.UpdateCommunity(updatedCommunity);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Community har uppdaterats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när community skulle uppdateras");
        }

        return RedirectToAction("Communities"); // Redirect to the community list or another appropriate action
    }
}