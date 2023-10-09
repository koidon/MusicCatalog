using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Services.Reviews;

public class SongReviewsViewComponent : ViewComponent
{
    private readonly IReviewService _reviewService;

    public SongReviewsViewComponent(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string songId)
    {
        var reviews = await _reviewService.GetReviewsById(songId);
        return View(reviews);
    }
}