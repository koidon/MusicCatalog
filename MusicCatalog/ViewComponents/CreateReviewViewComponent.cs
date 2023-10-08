using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Services.Reviews;

namespace MusicCatalog.ViewComponents;

public class CreateReviewViewComponent : ViewComponent
{
    private readonly IReviewService _reviewService;

    public CreateReviewViewComponent(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public IViewComponentResult Invoke(CreateReviewDto review)
    {
        return View(review);
    }
}