using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;
using MusicCatalog.Services.Reviews;

namespace MusicCatalog.Controllers;

public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    private readonly UserManager<IdentityUser> _userManager;

    public ReviewController(IReviewService reviewService, UserManager<IdentityUser> userManager)
    {
        _reviewService = reviewService;
        _userManager = userManager;
    }

    /*[HttpGet]
    [Authorize]
    public IActionResult CreateReview()
    {
        return View();
    } */


   /* [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateReview(CreateReviewDto review)
    {
        try
        {

            if (!ModelState.IsValid)
            {

                return View("~/Views/Home/Release.cshtml", new Song());
            }


            await _reviewService.CreateReview(review);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            return RedirectToAction("Error", "Home");
        }

        return RedirectToAction("Release", "Home", new {songId=review.SongId});
    } */


   /* [HttpGet]
    public async Task<IActionResult> SongReviews(string songId)
    {

        var reviews = await _reviewService.GetReviewsById(songId);

        return PartialView("SongReviews", reviews);
    }*/

/*
      [HttpGet]
      public IActionResult GetReview(int id)
      {
          return View();
      }
      [HttpPut]
      public IActionResult UpsertReview(Review review)
      {


          return View();
      }

      [HttpDelete]
      public IActionResult DeleteReview(int id)
      {
          return View();
      } */
}