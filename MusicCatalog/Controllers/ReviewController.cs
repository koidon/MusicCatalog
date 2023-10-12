using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Enums;
using MusicCatalog.Services;
using MusicCatalog.Services.Reviews;

namespace MusicCatalog.Controllers;

public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateReview(CreateReviewDto review)
    {
        try
        {
            if (!ModelState.IsValid)
                ViewComponent("CreateReview");

            await _reviewService.CreateReview(review);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Recensionen har skapats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när recensionen skulle skapas");
        }

        return RedirectToAction("Release", "Home", new { songId = review.SongId });
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> UpdateReview(int id)
    {
        try
        {
            var review = await _reviewService.GetReviewById(id);
            return View(review);
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när recensionen skulle hämtas");
        }


        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateReview(UpdateReviewDto review)
    {
        try
        {
            if (!ModelState.IsValid)
                return View();

            await _reviewService.UpdateReview(review);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Recensionen har uppdaterats");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när recensionen skulle uppdateras");
        }

        return RedirectToAction("Release", "Home", new { songId = review.SongId });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeleteReview(int reviewId, string songId)
    {

        try
        {
            await _reviewService.DeleteReview(reviewId);

            TempData["Alert"] = AlertService.ShowAlert(Alerts.Success, "Recensionen har tagits bort");
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när recensionen skulle tas bort");
        }

        return RedirectToAction("Release", "Home", new { songId });
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